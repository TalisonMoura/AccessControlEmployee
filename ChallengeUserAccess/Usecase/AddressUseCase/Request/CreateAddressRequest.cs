using System.ComponentModel.DataAnnotations;

namespace ChallengeUserAccess.Usecase.AddressUseCase.Request;

public class CreateAddressRequest
{
    [Required]
    [MinLength(2)]
    [MaxLength(2)]
    public string State { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string City { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Patio { get; set; }

    [Required]
    [MinLength(5)]
    public int Number { get; set; }

    [Required]
    public Guid EmployeeId { get; set; }
}
