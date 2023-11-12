using System.ComponentModel.DataAnnotations;

namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

public class CreateEmployeeRequest
{
    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public string Cpf { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(50)]
    public string FullName { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(15)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(40)]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    [Required]
    [Compare("Password")] 
    public string RePassword { get; set; }
}
