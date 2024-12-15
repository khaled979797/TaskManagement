using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Comments.Commands.Models
{
    public class AddCommentCommand : IRequest<NewResponse<string>>
    {
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
    }
}
