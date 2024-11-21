using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<Schedule> AddSchedule(Schedule schedule);
        Task<Schedule> EditSchedule(int id, DateTime notifyDate);
        Task<string> DeleteScheduleById(int id);
        Task<List<Schedule>> GetAllSchedules();
        Task<List<Schedule>> GetAllSchedulesForUser(int userId);
        Task<Schedule> GetScheduleById(int id);
    }
}
