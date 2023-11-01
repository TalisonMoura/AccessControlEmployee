using System.Text.Json.Serialization;

namespace ChallengeUserAccess.Usecase.AddressUseCase.Request;

public class UpdateAddressRequest : CreateAddressRequest 
{
    [JsonIgnore] public DateTime ModifydAt { get; set; }
}
