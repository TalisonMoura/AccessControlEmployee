using ChallengeUserAccess.Entities;
using System.Security.Claims;

namespace ChallengeUserAccess.Services;

public static class ClaimService
{
    public static ClaimsIdentity GenerateClaims(this Employee employee)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, employee.Email));
        foreach (var role in employee.Roles)
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
        }
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, employee.Id.ToString()));

        return claimsIdentity;
    }
}
