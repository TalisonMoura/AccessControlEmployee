using AutoMapper;
using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Data;
using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ChallengeUserAccess.Exceptions;

namespace ChallengeUserAccess.Services;

public class EmployeeService : IEmployeeService
{
    private readonly RepositoryDbContext _repository;
    private readonly IMapper _mapper;
    private readonly IEmployeeValidation _validation;
    public EmployeeService(RepositoryDbContext repository, IMapper mapper, IEmployeeValidation validation)
    {
        _repository = repository;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
    {
        request = _validation.EmpCreateValidate(request);
        var employee = _mapper.Map<Employee>(request);
        await _repository.Employees.AddAsync(employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateEmployeeResponse>(employee);
    }

    public async Task<ICollection<SearchEmployeeResponse>> GetEmployeesAsync()
    {
        var response = await _repository.Employees.Include(x => x.Address).ToListAsync();
        return _mapper.Map<ICollection<SearchEmployeeResponse>>(response);
    }

    public async Task<SearchEmployeeResponse> GetEmployeeByIdAsync(Guid id)
    {
        var response = await _repository.Employees.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id) 
            ?? throw new InvalidObjectException("This profile does not exist");
        return _mapper.Map<SearchEmployeeResponse>(response);
    }

    public async Task<UpdateEmployeeResponse> UpdateEmployeeAsync(Guid id,JsonPatchDocument<UpdateEmployeeRequest> request)
    {
        var employee = await _repository.Employees.FirstOrDefaultAsync(x => x.Id == id) 
            ?? throw new InvalidObjectException("This profile does not exist");
        var employeeUpdate = _mapper.Map<UpdateEmployeeRequest>(employee);
        employeeUpdate = _validation.EmpUpdateValidate(employeeUpdate);
        employeeUpdate.ModifydAt = DateTime.UtcNow;
        request.ApplyTo(employeeUpdate);

        var neWEmployee = _mapper.Map(employeeUpdate, employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateEmployeeResponse>(neWEmployee);
    }

    public async Task<DeleteEmployeeResponse> DeleteEmployeeAsync(Guid id)
    {
        var employee = await _repository.Employees.FirstOrDefaultAsync(x => x.Id == id) 
            ?? throw new InvalidObjectException("This profile does not exist");
        _repository.Employees.Remove(employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<DeleteEmployeeResponse>(employee);
    }

}
