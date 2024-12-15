using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Core.Features.Assignments.Queries.Models
{
    public class GetAssignmentsByUserQuery : IRequest<NewResponse<List<GetAssignmentsResponse>>>
    {
        public int Id { get; set; }
        public GetAssignmentsByUserQuery(int id)
        {
            Id = id;
        }
    }
}
