using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Notifications.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Notifications.Queries.Handlers
{
    public class NotificationQueryHandler : ResponseHandler,
        IRequestHandler<GetNotificationsQuery, NewResponse<List<GetNotificationsResponse>>>,
        IRequestHandler<GetNotificationByIdQuery, NewResponse<GetNotificationByIdResponse>>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public NotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<List<GetNotificationsResponse>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await notificationRepository.GetAllNotifications(request.UserId);
            if (notifications is null) return NotFound<List<GetNotificationsResponse>>();
            return Success(mapper.Map<List<GetNotificationsResponse>>(notifications));
        }

        public async Task<NewResponse<GetNotificationByIdResponse>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notifications = await notificationRepository.GetNotificationById(request.Id);
            if (notifications is null) return NotFound<GetNotificationByIdResponse>();
            return Success(mapper.Map<GetNotificationByIdResponse>(notifications));
        }
    }
}
