using TaskManagement.Core.Features.Notifications.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.NotificationMapping
{
    public partial class NotificationMappingProfile
    {
        public void AddNotificationMapping()
        {
            CreateMap<AddNotificationCommand, Notification>();
        }
    }
}
