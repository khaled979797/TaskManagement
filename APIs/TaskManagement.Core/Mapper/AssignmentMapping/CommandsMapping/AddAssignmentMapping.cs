using TaskManagement.Core.Features.Assignments.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.AssignmentMapping
{
    public partial class AssignmentMappingProfile
    {
        public void AddAssignmentMapping()
        {
            CreateMap<AddAssignmentCommand, Assignment>();
        }
    }
}
