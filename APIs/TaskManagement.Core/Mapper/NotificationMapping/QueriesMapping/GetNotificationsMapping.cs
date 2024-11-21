using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Notifications.Queries;

namespace TaskManagement.Core.Mapper.NotificationMapping
{
    public partial class NotificationMappingProfile
    {
        public void GetNotificationsMapping()
        {
            CreateMap<Notification, GetNotificationsResponse>();
        }
    }
}
