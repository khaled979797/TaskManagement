using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Queries;

namespace TaskManagement.Core.Mapper.UserMapping
{
    public partial class UserMappingProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
