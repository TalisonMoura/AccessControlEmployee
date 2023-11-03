using System.ComponentModel.DataAnnotations;

namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

public class RegisterLoginEmployeeRequest
{
    [Required]
    [MaxLength(40)]
    public string UserNameOrEmail { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    public string Password { get; set; }
}
