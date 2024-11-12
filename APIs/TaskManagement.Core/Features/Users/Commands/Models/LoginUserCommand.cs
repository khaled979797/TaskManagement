using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Users.Commands;

namespace TaskManagement.Core.Features.Users.Commands.Models
{
    public class LoginUserCommand : IRequest<NewResponse<LoginUserResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
