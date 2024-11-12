using AutoMapper;

namespace TaskManagement.Core.Mapper.UserMapping
{
    public partial class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            #region Commands
            AddRegisterUserMapping();
            AddEditUserMapping();
            #endregion

            #region Queries
            AddGetUsersMapping();
            AddGetUserByIdMapping();
            #endregion
        }
    }
}
