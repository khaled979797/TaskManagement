using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Comments.Commands.Models
{
    public class DeleteCommentCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
