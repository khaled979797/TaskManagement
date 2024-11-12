using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Users.Queries;

namespace TaskManagement.Core.Features.Users.Queries.Models
{
    public class GetUsersQuery : IRequest<NewResponse<List<GetUsersResponse>>>
    {
    }
}
