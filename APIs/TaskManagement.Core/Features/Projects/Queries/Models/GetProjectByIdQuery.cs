using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Projects.Queries;

namespace TaskManagement.Core.Features.Projects.Queries.Models
{
    public class GetProjectByIdQuery : IRequest<NewResponse<GetProjectByIdResponse>>
    {
        public int Id { get; set; }

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
