using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DotNetEnv;

namespace ChallengeUserAccess.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(Employee employee)
    {
        var handler  = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(Env.GetString("SymmetricSecurityKey"));

        var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = employee.GenerateClaims(),
            SigningCredentials = credential,
            Expires = DateTime.UtcNow.AddHours(5),
        };
        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}
