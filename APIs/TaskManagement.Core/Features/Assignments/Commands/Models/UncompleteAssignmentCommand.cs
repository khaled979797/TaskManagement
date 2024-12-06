using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Features.Assignments.Commands.Models
{
    public class UncompleteAssignmentCommand : IRequest<NewResponse<Assignment>>
    {
        public int Id { get; set; }
        public UncompleteAssignmentCommand(int id)
        {
            Id = id;
        }
    }
}
