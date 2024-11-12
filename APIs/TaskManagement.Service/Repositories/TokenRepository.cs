using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly SymmetricSecurityKey key;
        private readonly UserManager<AppUser> userManager;

        public TokenRepository(JwtSettings jwtSettings, UserManager<AppUser> userManager)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            this.userManager = userManager;
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new (JwtRegisteredClaimNames.UniqueName, user.UserName!)
            };

            var roles = await userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
