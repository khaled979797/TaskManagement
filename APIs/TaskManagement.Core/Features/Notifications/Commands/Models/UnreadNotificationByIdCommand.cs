using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Commands;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class UnreadNotificationByIdCommand : IRequest<NewResponse<UnreadNotificationByIdResponse>>
    {
        public int Id { get; set; }
        public UnreadNotificationByIdCommand(int id)
        {
            Id = id;
        }
    }
}
