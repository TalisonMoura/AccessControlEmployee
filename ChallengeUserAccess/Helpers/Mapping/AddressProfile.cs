using AutoMapper;
using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.AddressUseCase.Request;
using ChallengeUserAccess.Usecase.AddressUseCase.Response;

namespace ChallengeUserAccess.Helpers.Mapping;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressRequest, Address>();
        CreateMap<UpdateAddressRequest, Address>();
        CreateMap<Address, UpdateAddressRequest>();
        CreateMap<Address, CreateAddressResponse>();
        CreateMap<Address, SearchAddresResponse>();
        CreateMap<Address, DeleteAddressResponse>();
    }
}
