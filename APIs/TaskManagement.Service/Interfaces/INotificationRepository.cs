using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<Notification> AddNotification(Notification notification);
        Task<List<Notification>> ReadAllNotifications(int userId);
        Task<List<Notification>> UnreadAllNotifications(int userId);
        Task<Notification> ReadNotificationById(int id);
        Task<Notification> UnreadNotificationById(int id);
        Task<string> DeleteNotificationById(int id);
        Task<string> DeleteAllNotifications(int userId);
        Task<List<Notification>> GetAllNotifications(int userId);
        Task<Notification> GetNotificationById(int id);
    }
}
