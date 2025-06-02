using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VG.backend.Authentication
{
    public class AuthService
    {
        private readonly IConfiguration config;

        public AuthService(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateToken(string userId, string username, string role)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddMinutes(double.Parse(this.config["Jwt:ExpiresInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: this.config["Jwt:Issuer"],
                audience: this.config["Jwt:Audience"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
