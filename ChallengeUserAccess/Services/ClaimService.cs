using ChallengeUserAccess.Entities;
using System.Security.Claims;

namespace ChallengeUserAccess.Services;

public static class ClaimService
{
    /// <summary>
    /// This function is responsible for gerenate claims for one employee
    /// </summary>
    /// <param name="employee">Type required to generate claim</param>
    /// <returns></returns>
    public static ClaimsIdentity GenerateClaims(this Employee employee)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim("Id", employee.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, employee.FullName));
        foreach (var role in employee.Roles)
        { claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name)); }

        return claimsIdentity;
    }
}
