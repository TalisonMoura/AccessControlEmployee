namespace ChallengeUserAccess.Usecase.AddressUseCase.Response;

public class CreateAddressResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; }
}
