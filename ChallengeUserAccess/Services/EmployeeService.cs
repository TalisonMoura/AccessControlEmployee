using AutoMapper;
using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Data;
using ChallengeUserAccess.Entities;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Services;

public class EmployeeService : IEmployeeService
{
    private readonly Repository _repository;
    private readonly IMapper _mapper;
    public EmployeeService(Repository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
    {
        if (request == null) throw new ArgumentNullException("Parameters cannot be null");
        var employee = _mapper.Map<Employee>(request);
        await _repository.Employees.AddAsync(employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateEmployeeResponse>(employee);
    }

    public async Task<ICollection<SearchEmployeeResponse>> GetEmployeesAsync()
    {
        var response = await _repository.Employees.ToListAsync();
        return _mapper.Map<ICollection<SearchEmployeeResponse>>(response);
    }

    public async Task<SearchEmployeeResponse> GetEmployeeByIdAsync(Guid id)
    {
        var response = await _repository.Employees.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentNullException("This Employee doesn't exist");
        return _mapper.Map<SearchEmployeeResponse>(response);
    }

    public async Task<UpdateEmployeeResponse> UpdateEmployeeAsync(Guid id,JsonPatchDocument<UpdateEmployeeRequest> request)
    {
        if (request == null) throw new ArgumentNullException("Parameters cannot be null");
        var employee = await _repository.Employees.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentNullException("This Employee doesn't exist");
        var employeeUpdate = _mapper.Map<UpdateEmployeeRequest>(employee);
        request.ApplyTo(employeeUpdate);

        var neWEmployee = _mapper.Map(employeeUpdate, employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateEmployeeResponse>(neWEmployee);
    }
    public async Task<DeleteEmployeeResponse> DeleteEmployeeAsync(Guid id)
    {
        var employee = await _repository.Employees.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("The Id doesn't exist in database");
        _repository.Employees.Remove(employee);
        await _repository.SaveChangesAsync();
        return _mapper.Map<DeleteEmployeeResponse>(employee);
    }

}
