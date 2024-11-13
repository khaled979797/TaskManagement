using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
