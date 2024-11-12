using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
    }
}
