using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }
    }
}
