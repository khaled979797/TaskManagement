using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Commands;

namespace TaskManagement.Core.Features.Notifications.Commands.Models
{
    public class ReadNotificationByIdCommand : IRequest<NewResponse<ReadNotificationByIdResponse>>
    {
        public int Id { get; set; }
        public ReadNotificationByIdCommand(int id)
        {
            Id = id;
        }
    }
}
