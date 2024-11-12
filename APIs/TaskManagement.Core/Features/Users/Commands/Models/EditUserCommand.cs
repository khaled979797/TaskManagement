using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
