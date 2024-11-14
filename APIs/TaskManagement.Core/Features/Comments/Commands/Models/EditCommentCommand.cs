using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Comments.Commands.Models
{
    public class EditCommentCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
    }
}
