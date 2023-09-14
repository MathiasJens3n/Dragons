using Dragons.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dragons.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var tokenExpirationInHours = 1;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(null, null, claims, null, DateTime.Now.AddMinutes(tokenExpirationInHours), new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));

            string tokenvalue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenvalue;
        }
    }
}