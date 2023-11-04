using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Controllers.Base;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ChallengeUserAccess.Controllers;

[ApiController]
[Route("/Employee")]
[Authorize(Roles = "admin")]
public class EmployeeController : MainController
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateEmployeeResponse))]
    public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeRequest request)
    {
        var response = await _employeeService.CreateEmployeeAsync(request);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SearchEmployeeResponse))]
    public async Task<IEnumerable> GetEmployeesAsync()
    {
        var response = await _employeeService.GetEmployeesAsync();
        return response;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SearchEmployeeResponse))]
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id)
    {
        var response = await _employeeService.GetEmployeeByIdAsync(id);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UpdateEmployeeResponse))]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, JsonPatchDocument<UpdateEmployeeRequest> request)
    {
        var response = await _employeeService.UpdateEmployeeAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeleteEmployeeResponse))]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var response = await _employeeService.DeleteEmployeeAsync(id);
        return Ok(response);
    }
}
