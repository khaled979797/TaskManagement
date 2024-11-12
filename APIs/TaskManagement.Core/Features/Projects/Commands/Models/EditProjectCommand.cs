using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Projects.Commands.Models
{
    public class EditProjectCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
