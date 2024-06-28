using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelpDeskApi.Models;
using HelpDeskApi.Utils;
using Microsoft.IdentityModel.Tokens;

namespace HelpDeskApi.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var bytesKey = Encoding.ASCII.GetBytes(Configuration.ApiKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new (ClaimTypes.Name, user.Name),
                        new (ClaimTypes.Role, user.Role.Name )
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytesKey),
                                                            SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
