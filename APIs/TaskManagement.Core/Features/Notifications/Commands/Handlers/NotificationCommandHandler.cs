using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Notifications.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Notifications.Commands;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Notifications.Commands.Handlers
{
    public class NotificationCommandHandler : ResponseHandler,
        IRequestHandler<AddNotificationCommand, NewResponse<string>>,
        IRequestHandler<DeleteAllNotificationsCommand, NewResponse<string>>,
        IRequestHandler<DeleteNotificationByIdCommand, NewResponse<string>>,
        IRequestHandler<ReadAllNotificationsCommand, NewResponse<List<ReadAllNotificationsResponse>>>,
        IRequestHandler<ReadNotificationByIdCommand, NewResponse<ReadNotificationByIdResponse>>,
        IRequestHandler<UnreadAllNotificationsCommand, NewResponse<List<UnreadAllNotificationsResponse>>>,
        IRequestHandler<UnreadNotificationByIdCommand, NewResponse<UnreadNotificationByIdResponse>>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public NotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<string>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationMapper = mapper.Map<Notification>(request);
            var notification = await notificationRepository.AddNotification(notificationMapper);

            if (notification is null) return BadRequest<string>();
            return Success("");
        }

        public async Task<NewResponse<string>> Handle(DeleteAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var result = await notificationRepository.DeleteAllNotifications(request.UserId);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>("UserNotFound");
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }

        public async Task<NewResponse<string>> Handle(DeleteNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await notificationRepository.DeleteNotificationById(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }

        public async Task<NewResponse<List<ReadAllNotificationsResponse>>> Handle(ReadAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var notifications = await notificationRepository.ReadAllNotifications(request.UserId);
            if (notifications is null) return BadRequest<List<ReadAllNotificationsResponse>>();
            return Success(mapper.Map<List<ReadAllNotificationsResponse>>(notifications));
        }

        public async Task<NewResponse<ReadNotificationByIdResponse>> Handle(ReadNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            var notification = await notificationRepository.ReadNotificationById(request.Id);
            if (notification is null) return BadRequest<ReadNotificationByIdResponse>();
            return Success(mapper.Map<ReadNotificationByIdResponse>(notification));
        }

        public async Task<NewResponse<List<UnreadAllNotificationsResponse>>> Handle(UnreadAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var notifications = await notificationRepository.UnreadAllNotifications(request.UserId);
            if (notifications is null) return BadRequest<List<UnreadAllNotificationsResponse>>();
            return Success(mapper.Map<List<UnreadAllNotificationsResponse>>(notifications));
        }

        public async Task<NewResponse<UnreadNotificationByIdResponse>> Handle(UnreadNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            var notification = await notificationRepository.UnreadNotificationById(request.Id);
            if (notification is null) return BadRequest<UnreadNotificationByIdResponse>();
            return Success(mapper.Map<UnreadNotificationByIdResponse>(notification));
        }
    }
}
