using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Schedules.Commands.Models
{
    public class EditScheduleCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime NotifyDate { get; set; }
    }
}
