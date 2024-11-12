using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;

namespace TaskManagement.Service.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<AppRole> roleManager)
        {
            var rolesCount = await roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
                await roleManager.CreateAsync(new AppRole { Name = "User" });
            }
        }
    }
}
