using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Notifications.Commands;

namespace TaskManagement.Core.Mapper.NotificationMapping
{
    public partial class NotificationMappingProfile
    {
        public void ReadAllNotificationsMapping()
        {
            CreateMap<Notification, ReadAllNotificationsResponse>();
        }
    }
}
