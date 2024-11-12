using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.ProjectMapping
{
    public partial class ProjectMappingProfile
    {
        public void AddEditProjectMapping()
        {
            CreateMap<EditProjectCommand, Project>();
        }
    }
}
