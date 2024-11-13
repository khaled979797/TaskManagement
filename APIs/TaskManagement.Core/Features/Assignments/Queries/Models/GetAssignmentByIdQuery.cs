using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Core.Features.Assignments.Queries.Models
{
    public class GetAssignmentByIdQuery : IRequest<NewResponse<GetAssignmentByIdResponse>>
    {
        public int Id { get; set; }

        public GetAssignmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
