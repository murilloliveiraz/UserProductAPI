using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
