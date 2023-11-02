using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChallengeUserAccess.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Employee employee)
    {
        var handler  = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]);

        var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = employee.GenerateClaims(),
            SigningCredentials = credential,
            Expires = DateTime.UtcNow.AddHours(2),
        };
        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}
