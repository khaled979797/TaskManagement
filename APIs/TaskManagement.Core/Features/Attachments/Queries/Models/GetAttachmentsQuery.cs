using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Attachments.Queries;

namespace TaskManagement.Core.Features.Attachments.Queries.Models
{
    public class GetAttachmentsQuery : IRequest<NewResponse<List<GetAttachmentsResponse>>>
    {
        public int AssignmentId { get; set; }
        public GetAttachmentsQuery(int assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}
