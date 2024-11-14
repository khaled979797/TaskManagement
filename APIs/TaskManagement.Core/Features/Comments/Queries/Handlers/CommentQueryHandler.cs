using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Comments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Comments.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Comments.Queries.Handlers
{
    public class CommentQueryHandler : ResponseHandler,
        IRequestHandler<GetCommentsQuery, NewResponse<List<GetCommentsResponse>>>,
        IRequestHandler<GetCommentByIdQuery, NewResponse<GetCommentByIdResponse>>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<List<GetCommentsResponse>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await commentRepository.GetAllComments(request.AssignmentId);
            if (comments is null) return NotFound<List<GetCommentsResponse>>();
            var commentsMapper = mapper.Map<List<GetCommentsResponse>>(comments);
            return Success(commentsMapper);
        }

        public async Task<NewResponse<GetCommentByIdResponse>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await commentRepository.GetCommentById(request.Id);
            if (comment is null) return NotFound<GetCommentByIdResponse>();
            var commentMapper = mapper.Map<GetCommentByIdResponse>(comment);
            return Success(commentMapper);
        }
    }
}
