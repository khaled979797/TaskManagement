using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Commands;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly SignInManager<AppUser> signInManager;

        public UserRepository(AppDbContext context, UserManager<AppUser> userManager,
            ITokenRepository tokenRepository, SignInManager<AppUser> signInManager) : base(context)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.signInManager = signInManager;
        }

        public async Task<RegisterUserResponse> RegisterUser(AppUser user, string password)
        {
            var transact = await context.Database.BeginTransactionAsync();
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
                await transact.CommitAsync();
                return new RegisterUserResponse { UserName = user.UserName, Token = token };
            }
            catch
            {
                await transact.RollbackAsync();
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
            return new LoginUserResponse { UserName = user.UserName, Token = token };
        }

        public async Task<string> EditUser(AppUser user)
        {
            var transact = await context.Database.BeginTransactionAsync();
            try
            {
                var checkUser = await userManager.FindByIdAsync(user.Id.ToString());
                if (checkUser is null) return "NotFound";

                checkUser.Name = user.Name;
                checkUser.UserName = user.UserName;
                checkUser.Email = user.Email;
                await context.SaveChangesAsync();
                await transact.CommitAsync();
                return "Success";
            }
            catch
            {
                await transact.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> DeleteUser(string username)
        {
            var transact = await context.Database.BeginTransactionAsync();
            try
            {
                var user = await userManager.FindByNameAsync(username);
                if (user is null) return "NotFound";

                var result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) return "Failed";

                await context.SaveChangesAsync();
                await transact.CommitAsync();
                return "Success";
            }
            catch
            {
                await transact.RollbackAsync();
                return "Failed";
            }
        }
        public async Task<bool> IsUserNameExist(string username)
        {
            var user = await GetTableNoTracking().Where(x => x.UserName == username).FirstOrDefaultAsync();
            return user == null ? false : true;
        }

        public async Task<bool> IsUserNameExistExcludeSelf(string username, int id)
        {
            var user = await GetTableNoTracking().Where(x => x.UserName == username && x.Id != id).FirstOrDefaultAsync();
            return user == null ? false : true;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var user = await GetTableNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();
            return user == null ? false : true;
        }

        public async Task<bool> IsEmailExistExcludeSelf(string email, int id)
        {
            var user = await GetTableNoTracking().Where(x => x.Email == email && x.Id != id).FirstOrDefaultAsync();
            return user == null ? false : true;
        }
    }
}
