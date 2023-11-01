using ChallengeUserAccess.Entities;

namespace ChallengeUserAccess.Contracts;

public interface ITokenService
{
    string GenerateToken(Employee employee);
}
