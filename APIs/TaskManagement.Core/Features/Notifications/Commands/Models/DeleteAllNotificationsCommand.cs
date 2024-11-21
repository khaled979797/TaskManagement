using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class DeleteAllNotificationsCommand : IRequest<NewResponse<string>>
    {
        public int UserId { get; set; }
        public DeleteAllNotificationsCommand(int userId)
        {
            UserId = userId;
        }
    }
}