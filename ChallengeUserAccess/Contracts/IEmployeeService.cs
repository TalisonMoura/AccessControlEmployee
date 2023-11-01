using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;
using Microsoft.AspNetCore.JsonPatch;

namespace ChallengeUserAccess.Contracts;

public interface IEmployeeService
{
    Task<ICollection<SearchEmployeeResponse>> GetEmployeesAsync();
    Task<SearchEmployeeResponse> GetEmployeeByIdAsync(Guid id);
    Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request);
    Task<UpdateEmployeeResponse> UpdateEmployeeAsync(Guid id, JsonPatchDocument<UpdateEmployeeRequest> request);
    Task<DeleteEmployeeResponse> DeleteEmployeeAsync(Guid id);
}

