using AutoMapper;

namespace TaskManagement.Core.Mapper.ProjectMapping
{
    public partial class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            #region Commands
            AddProjectMapping();
            EditProjectMapping();
            #endregion

            #region Queries
            GetProjectsMapping();
            GetProjectByIdMapping();
            #endregion
        }
    }
}
