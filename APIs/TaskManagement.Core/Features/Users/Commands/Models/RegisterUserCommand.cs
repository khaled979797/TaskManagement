using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Users.Commands;

namespace TaskManagement.Core.Features.Users.Commands.Models
{
    public class RegisterUserCommand : IRequest<NewResponse<RegisterUserResponse>>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
