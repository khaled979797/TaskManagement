using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Commands;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class UnreadAllNotificationsCommand : IRequest<NewResponse<List<UnreadAllNotificationsResponse>>>
    {
        public int UserId { get; set; }
        public UnreadAllNotificationsCommand(int userId)
        {
            UserId = userId;
        }
    }
}
