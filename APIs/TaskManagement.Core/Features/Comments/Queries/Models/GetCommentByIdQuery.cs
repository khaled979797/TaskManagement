using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Comments.Queries;

namespace TaskManagement.Core.Features.Comments.Queries.Models
{
    public class GetCommentByIdQuery : IRequest<NewResponse<GetCommentByIdResponse>>
    {
        public int Id { get; set; }
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
