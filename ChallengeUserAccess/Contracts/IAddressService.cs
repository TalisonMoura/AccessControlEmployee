using ChallengeUserAccess.Usecase.AddressUseCase.Request;
using ChallengeUserAccess.Usecase.AddressUseCase.Response;
using Microsoft.AspNetCore.JsonPatch;

namespace ChallengeUserAccess.Contracts;

public interface IAddressService
{
    Task<ICollection<SearchAddresResponse>> GetAddressesAsync();
    Task<SearchAddresResponse> GetAddressByIdAsync(Guid id);
    Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest request);
    Task<UpdateAddressResponse> UpdateAddressAsync(Guid id, JsonPatchDocument<UpdateAddressRequest> request);
    Task<DeleteAddressResponse> DeleteAdressAsync(Guid id);
}
