using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Schedules.Commands.Models
{
    public class AddScheduleCommand : IRequest<NewResponse<string>>
    {
        public string? Message { get; set; }
        public DateTime NotifyDate { get; set; }
        public int UserId { get; set; }
    }
}
