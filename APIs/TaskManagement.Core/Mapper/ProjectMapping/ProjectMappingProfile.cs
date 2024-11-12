using AutoMapper;

namespace TaskManagement.Core.Mapper.ProjectMapping
{
    public partial class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            #region Commands
            AddProjectMapping();
            AddEditProjectMapping();
            #endregion

            #region Queries
            AddGetProjectsMapping();
            AddGetProjectByIdMapping();
            AddGetProjectByNameMapping();
            #endregion
        }
    }
}
