using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Commands;

namespace TaskManagement.Service.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<RegisterUserResponse> RegisterUser(AppUser user, string password);
        Task<LoginUserResponse> LoginUser(string username, string password);
        Task<string> EditUser(AppUser user);
        Task<string> DeleteUser(string username);
        Task<bool> IsUserNameExist(string username);
        Task<bool> IsUserNameExistExcludeSelf(string username, int id);
        Task<bool> IsEmailExist(string email);
        Task<bool> IsEmailExistExcludeSelf(string email, int id);
    }
}
