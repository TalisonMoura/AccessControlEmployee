using AutoMapper;
using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;

namespace ChallengeUserAccess.Helpers.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<RegisterLoginEmployeeRequest, Employee>();
        CreateMap<Employee, UpdateEmployeeRequest>();
        CreateMap<Employee, CreateEmployeeResponse>();
        CreateMap<Employee, SearchEmployeeResponse>();
        CreateMap<Employee, UpdateEmployeeResponse>();
        CreateMap<Employee, DeleteEmployeeResponse>();    
    }
}
