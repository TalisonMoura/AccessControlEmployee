namespace ChallengeUserAccess.Usecase.AddressUseCase.Request;

public class CreateAddressRequest
{
    public string State { get; set; }
    public string City { get; set; }
    public string Patio { get; set; }
    public int Number { get; set; }
}
