using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Projects.Queries;

namespace TaskManagement.Core.Features.Projects.Queries.Models
{
    public class GetProjectsQuery : IRequest<NewResponse<List<GetProjectsResponse>>>
    {
    }
}
