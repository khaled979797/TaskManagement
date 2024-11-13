using AutoMapper;

namespace TaskManagement.Core.Mapper.UserMapping
{
    public partial class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            #region Commands
            RegisterUserMapping();
            EditUserMapping();
            #endregion

            #region Queries
            GetUsersMapping();
            GetUserByIdMapping();
            #endregion
        }
    }
}
