using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class DeleteNotificationByIdCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteNotificationByIdCommand(int id)
        {
            Id = id;
        }
    }
}
