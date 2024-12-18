using Hangfire;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Schedule> AddSchedule(Schedule schedule)
        {
            await BeginTransactionAsync();
            try
            {
                var delay = schedule.NotifyDate - DateTime.UtcNow;
                var jobId = BackgroundJob.Schedule<INotificationRepository>(x => x.AddNotification(new Notification
                { Message = schedule.Message, UserId = schedule.UserId }), TimeSpan.FromSeconds(delay.TotalSeconds));

                schedule.JobId = int.Parse(jobId);
                var newSchedule = await AddAsync(schedule);
                if (newSchedule is null) return null!;
                await CommitAsync();
                return newSchedule;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }


        public async Task<Schedule> EditSchedule(Schedule schedule)
        {
            await BeginTransactionAsync();
            try
            {
                var scheduleInDb = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == schedule.Id);
                if (scheduleInDb is null) return null!;

                var delay = schedule.NotifyDate - DateTime.UtcNow;
                BackgroundJob.Reschedule(scheduleInDb.JobId.ToString(), TimeSpan.FromSeconds(delay.TotalSeconds));

                scheduleInDb.NotifyDate = schedule.NotifyDate;
                scheduleInDb.Message = schedule.Message;
                await UpdateAsync(scheduleInDb);
                await CommitAsync();
                return scheduleInDb;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<string> DeleteScheduleById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var schedule = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (schedule is null) return "NotFound";

                await DeleteAsync(schedule);
                BackgroundJob.Delete(schedule.JobId.ToString());
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            var schedules = await GetTableNoTracking().Include(x => x.User).OrderByDescending(x => x.NotifyDate).ToListAsync();
            return schedules.Count() > 0 ? schedules : null!;
        }

        public async Task<List<Schedule>> GetAllSchedulesForUser(int userId)
        {
            var schedules = await GetTableNoTracking().Where(x => x.UserId == userId)
                .Include(x => x.User).OrderByDescending(x => x.NotifyDate).ToListAsync();
            return schedules.Count() > 0 ? schedules : null!;
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            return await GetTableNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }
    }
}
