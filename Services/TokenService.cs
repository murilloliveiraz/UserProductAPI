using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("role", user.Role)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyTpbGjkOiJADzI1NiIsInR5cCA6IkpY"));

            var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
