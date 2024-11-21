using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class AddNotificationCommand : IRequest<NewResponse<string>>
    {
        public string? Message { get; set; }
        public int UserId { get; set; }
    }
}
