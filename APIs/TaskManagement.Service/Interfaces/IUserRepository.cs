using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Commands;

namespace TaskManagement.Service.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<RegisterUserResponse> RegisterUser(User user, string password);
        Task<LoginUserResponse> LoginUser(string username, string password);
        Task<string> EditUser(User user);
        Task<string> DeleteUser(int id);
        Task<bool> IsUserNameExist(string username);
        Task<bool> IsUserNameExistExcludeSelf(string username, int id);
        Task<bool> IsEmailExist(string email);
        Task<bool> IsEmailExistExcludeSelf(string email, int id);
    }
}
