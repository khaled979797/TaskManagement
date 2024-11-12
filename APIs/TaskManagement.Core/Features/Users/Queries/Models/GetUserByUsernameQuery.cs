using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Users.Queries;

namespace TaskManagement.Core.Features.Users.Queries.Models
{
    public class GetUserByUsernameQuery : IRequest<NewResponse<GetUserByUsernameResponse>>
    {
        public string Username { get; set; }
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
