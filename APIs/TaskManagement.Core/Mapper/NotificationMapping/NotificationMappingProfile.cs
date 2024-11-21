using AutoMapper;

namespace TaskManagement.Core.Mapper.NotificationMapping
{
    public partial class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            #region Commands
            AddNotificationMapping();
            ReadAllNotificationsMapping();
            ReadNotificationByIdMapping();
            UnreadAllNotificationsMapping();
            UnreadNotificationByIdMapping();
            #endregion

            #region Queries
            GetNotificationsMapping();
            GetNotificationByIdMapping();
            #endregion
        }
    }
}
