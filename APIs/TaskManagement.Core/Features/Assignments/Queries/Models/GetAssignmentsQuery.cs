using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Core.Features.Assignments.Queries.Models
{
    public class GetAssignmentsQuery : IRequest<NewResponse<List<GetAssignmentsResponse>>>
    {
    }
}
