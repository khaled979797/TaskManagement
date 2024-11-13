using AutoMapper;

namespace TaskManagement.Core.Mapper.AssignmentMapping
{
    public partial class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            #region Commands
            AddAssignmentMapping();
            EditAssignmentMapping();
            #endregion

            #region Queries
            GetAssignmentsMapping();
            GetAssignmentByIdMapping();
            #endregion
        }
    }
}
