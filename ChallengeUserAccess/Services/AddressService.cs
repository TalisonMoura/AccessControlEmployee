using AutoMapper;
using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Data;
using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.AddressUseCase.Request;
using ChallengeUserAccess.Usecase.AddressUseCase.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Services;

public class AddressService : IAddressService
{
    private readonly RepositoryDbContext _repository;
    private readonly IMapper _mapper;
    public AddressService(RepositoryDbContext repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest request)
    {
        if (request == null) throw new ArgumentNullException("Parameters cannot be null");
        var address = _mapper.Map<Address>(request);
        await _repository.Address.AddAsync(address);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateAddressResponse>(address);
    }
    public async Task<ICollection<SearchAddresResponse>> GetAddressesAsync()
    {
        var response = await _repository.Address.ToListAsync();
        return _mapper.Map<ICollection<SearchAddresResponse>>(response);
    }
    public async Task<SearchAddresResponse> GetAddressByIdAsync(Guid id)
    {
        var response = await _repository.Address.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentNullException("This Address doesn't exist");
        return _mapper.Map<SearchAddresResponse>(response);
    }
    public async Task<UpdateAddressResponse> UpdateAddressAsync(Guid id, JsonPatchDocument<UpdateAddressRequest> request)
    {
        if (request == null) throw new ArgumentNullException("Parameters cannot be null");
        var address = await _repository.Address.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentNullException("This Address doesn't exist");
        var addressUpdate = _mapper.Map<UpdateAddressRequest>(address);
        request.ApplyTo(addressUpdate);

        var neWAddress = _mapper.Map(addressUpdate, address);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateAddressResponse>(neWAddress);
    }
    public async Task<DeleteAddressResponse> DeleteAdressAsync(Guid id)
    {
        var address = await _repository.Address.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("The Id doesn't exist in database");
        _repository.Address.Remove(address);
        await _repository.SaveChangesAsync();
        return _mapper.Map<DeleteAddressResponse>(address);
    }
}
