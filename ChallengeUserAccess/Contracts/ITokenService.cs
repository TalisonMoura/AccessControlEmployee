using ChallengeUserAccess.Entities;
using System.Security.Claims;

namespace ChallengeUserAccess.Contracts;

public interface ITokenService
{
    string GenerateToken(Employee employee);
}
