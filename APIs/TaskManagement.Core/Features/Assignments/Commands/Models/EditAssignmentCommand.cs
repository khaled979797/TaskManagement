using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Enums;

namespace TaskManagement.Core.Features.Assignments.Commands.Models
{
    public class EditAssignmentCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
    }
}
