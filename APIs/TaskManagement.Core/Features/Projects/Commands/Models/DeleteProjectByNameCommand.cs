using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Projects.Commands.Models
{
    public class DeleteProjectByNameCommand : IRequest<NewResponse<string>>
    {
        public string Name { get; set; }
        public DeleteProjectByNameCommand(string name)
        {
            Name = name;
        }
    }
}
