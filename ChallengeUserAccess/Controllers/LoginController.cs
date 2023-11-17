using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Controllers.Base;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Response;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeUserAccess.Controllers;

[Route("/Login")]
public class LoginController : MainController
{
    private readonly ILoginService _loginService;
    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    /// <summary>
    /// This is a function to authenticate the employee
    /// </summary>
    /// <param name="request">The requirements fields to get authenticated</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegisterLoginEmployeeResponse))]
    public async Task<IActionResult> LoginAsync(RegisterLoginEmployeeRequest request)
    {
        var response = await _loginService.LoginAsync(request);
        return Ok(response);
    }
}
