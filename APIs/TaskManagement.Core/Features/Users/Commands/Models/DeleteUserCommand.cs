using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<NewResponse<string>>
    {
        public string Username { get; set; }
        public DeleteUserCommand(string username)
        {
            Username = username;
        }
    }
}
