using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Data;
using ChallengeUserAccess.Exceptions;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Services;

public class LoginService : ILoginService
{
    private readonly ITokenService _tokenService;
    private readonly RepositoryDbContext _repository;
    private readonly ILoginValidation _loginValidation;
    public LoginService(RepositoryDbContext repository, ITokenService tokenService, ILoginValidation loginValidation)
    {
        _repository = repository;
        _tokenService = tokenService;
        _loginValidation = loginValidation;
    }

    public async Task<string> LoginAsync(RegisterLoginEmployeeRequest request)
    {
        try
        {
            request = _loginValidation.ValidateLoginCredentials(request);
            var term = request.UserNameOrEmail;
            var login = await _repository.Employees
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x =>
                (x.Email.Equals(term) || x.UserName.Equals(term))
                && x.Password.Equals(request.Password)) ?? throw new InvalidObjectException("This profile does not exist");
            return _tokenService.GenerateToken(login);
        }
        catch (InvalidObjectException ex)
        {
            return ex.Message;
        }
    }
}
