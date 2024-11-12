using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> CreateToken(AppUser user);
    }
}
