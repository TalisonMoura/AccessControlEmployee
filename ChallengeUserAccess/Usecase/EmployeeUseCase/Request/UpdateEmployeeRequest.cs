using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

public class UpdateEmployeeRequest
{
    [MinLength(5)]
    [MaxLength(15)]
    public string UserName { get; set; }

    [MaxLength(40)]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [MinLength(10)]
    [MaxLength(20)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password")]
    public string RePassword { get; set; }

    [JsonIgnore] 
    public DateTime ModifydAt { get; set; }
}
