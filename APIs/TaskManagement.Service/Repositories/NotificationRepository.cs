using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context) { }

        public async Task<Notification> AddNotification(Notification notification)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == notification.UserId);
                if (user is null) return null!;

                var newNotification = await AddAsync(notification);
                if (newNotification is null) return null!;
                await CommitAsync();
                return newNotification;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<string> DeleteAllNotifications(int userId)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user is null) return "UserNotFound";

                var notifications = await GetTableNoTracking().Where(x => x.UserId == userId).ToListAsync();
                if (notifications is null) return "NotFound";

                await DeleteRangeAsync(notifications);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<string> DeleteNotificationById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var notification = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (notification is null) return "NotFound";

                await DeleteAsync(notification);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<List<Notification>> GetAllNotifications(int userId)
        {
            var notifications = await GetTableNoTracking().Where(x => x.UserId == userId)
                .OrderByDescending(x => x.TimeStamp).ToListAsync();
            return notifications.Count() > 0 ? notifications : null!;
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }

        public async Task<List<Notification>> ReadAllNotifications(int userId)
        {
            await BeginTransactionAsync();
            try
            {
                var notifications = await GetTableNoTracking().Where(x => x.UserId == userId).ToListAsync();
                if (notifications == null) return null!;

                notifications.ForEach(n => n.IsRead = true);
                await UpdateRangeAsync(notifications);
                await CommitAsync();
                return notifications;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<Notification> ReadNotificationById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var notification = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (notification == null) return null!;

                notification.IsRead = true;
                await UpdateAsync(notification);
                await CommitAsync();
                return notification;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<List<Notification>> UnreadAllNotifications(int userId)
        {
            await BeginTransactionAsync();
            try
            {
                var notifications = await GetTableNoTracking().Where(x => x.UserId == userId).ToListAsync();
                if (notifications == null) return null!;

                notifications.ForEach(n => n.IsRead = false);
                await UpdateRangeAsync(notifications);
                await CommitAsync();
                return notifications;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<Notification> UnreadNotificationById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var notification = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (notification == null) return null!;

                notification.IsRead = false;
                await UpdateAsync(notification);
                await CommitAsync();
                return notification;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }
    }
}
