using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Assignments.Commands.Models
{
    public class DeleteAssignmentCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }

        public DeleteAssignmentCommand(int id)
        {
            Id = id;
        }
    }
}
