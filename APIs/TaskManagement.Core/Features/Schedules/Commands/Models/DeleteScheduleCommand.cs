using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Schedules.Commands.Models
{
    public class DeleteScheduleCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteScheduleCommand(int id)
        {
            Id = id;
        }
    }
}
