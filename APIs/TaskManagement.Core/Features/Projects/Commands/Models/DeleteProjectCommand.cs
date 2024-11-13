using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Projects.Commands.Models
{
    public class DeleteProjectCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
