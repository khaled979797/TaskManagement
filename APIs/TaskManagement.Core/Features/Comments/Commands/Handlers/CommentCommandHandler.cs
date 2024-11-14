using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Comments.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Comments.Commands.Handlers
{
    public class CommentCommandHandler : ResponseHandler,
        IRequestHandler<AddCommentCommand, NewResponse<string>>,
        IRequestHandler<EditCommentCommand, NewResponse<string>>,
        IRequestHandler<DeleteCommentCommand, NewResponse<string>>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<string>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var commentMapper = mapper.Map<Comment>(request);
            var comment = await commentRepository.AddComment(commentMapper);
            if (comment is null) return BadRequest<string>();
            return Success($"Comment Added With Id: {comment.Id}");
        }

        public async Task<NewResponse<string>> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var commentMapper = mapper.Map<Comment>(request);
            var result = await commentRepository.EditComment(commentMapper);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "UserNotFound": return NotFound<string>("UserNotFound");
                case "AssignmentNotFound": return NotFound<string>("AssignmentNotFound");
                case "Failed": return BadRequest<string>();
                default: return Success("");
            }
        }

        public async Task<NewResponse<string>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await commentRepository.DeleteComment(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }
    }
}
