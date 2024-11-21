using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Commands;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class ReadAllNotificationsCommand : IRequest<NewResponse<List<ReadAllNotificationsResponse>>>
    {
        public int UserId { get; set; }
        public ReadAllNotificationsCommand(int userId)
        {
            UserId = userId;
        }
    }
}
