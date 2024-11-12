using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Projects.Commands.Models
{
    public class DeleteProjectByIdCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteProjectByIdCommand(int id)
        {
            Id = id;
        }
    }
}
