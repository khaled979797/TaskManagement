using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Commands;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly SignInManager<User> signInManager;
        public UserRepository(AppDbContext context, UserManager<User> userManager,
            ITokenRepository tokenRepository, SignInManager<User> signInManager) : base(context)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.signInManager = signInManager;
        }

        public async Task<RegisterUserResponse> RegisterUser(User user, string password)
        {
            await BeginTransactionAsync();
            try
            {
                var checkEmailExist = await userManager.FindByEmailAsync(user.Email!);
                if (checkEmailExist is not null) return null!;

                var checkUsernameExist = await userManager.FindByNameAsync(user.UserName!);
                if (checkUsernameExist is not null) return null!;

                var token = await tokenRepository.CreateToken(user);
                var result = await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded) return null!;
                await CommitAsync();
                return new RegisterUserResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Email = user.Email,
                    Token = token
                };
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<LoginUserResponse> LoginUser(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user is null) return null!;

            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded) return null!;

            var token = await tokenRepository.CreateToken(user);
            return new LoginUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<string> EditUser(User user)
        {
            await BeginTransactionAsync();
            try
            {
                var userInDb = await userManager.FindByIdAsync(user.Id.ToString());
                if (userInDb is null) return "NotFound";

                userInDb.Name = user.Name;
                userInDb.UserName = user.UserName;
                userInDb.NormalizedUserName = user.UserName!.ToUpper();
                userInDb.Email = user.Email;

                await SaveChangesAsync();
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<string> DeleteUser(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());
                if (user is null) return "NotFound";

                var result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) return "Failed";

                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<bool> IsUserNameExist(string username)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.UserName == username) != null;
        }

        public async Task<bool> IsUserNameExistExcludeSelf(string username, int id)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.UserName == username && x.Id != id) != null;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Email == email) != null;
        }

        public async Task<bool> IsEmailExistExcludeSelf(string email, int id)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.Id != id) != null;
        }
    }
}
