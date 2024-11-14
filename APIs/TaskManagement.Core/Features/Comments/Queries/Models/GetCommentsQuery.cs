using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Comments.Queries;

namespace TaskManagement.Core.Features.Comments.Queries.Models
{
    public class GetCommentsQuery : IRequest<NewResponse<List<GetCommentsResponse>>>
    {
        public int AssignmentId { get; set; }
        public GetCommentsQuery(int assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}
