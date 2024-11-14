using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;

namespace TaskManagement.Service.Seeders
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var usersCount = await userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var newUser = new User
                {
                    Name = "Admin",
                    UserName = "admin",
                    Email = "admin@project.com",
                    PhoneNumber = "123456",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(newUser, "Admin@1234");
                await userManager.AddToRoleAsync(newUser, "Admin");
            }
        }
    }
}
