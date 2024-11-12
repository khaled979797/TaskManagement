using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Projects.Queries;

namespace TaskManagement.Core.Features.Projects.Queries.Models
{
    public class GetProjectByNameQuery : IRequest<NewResponse<GetProjectByNameResponse>>
    {
        public string Name { get; set; }

        public GetProjectByNameQuery(string name)
        {
            Name = name;
        }
    }
}
