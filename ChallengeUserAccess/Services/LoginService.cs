using AutoMapper;
using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Data;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Services;

public class LoginService : ILoginService
{
    private readonly ITokenService _tokenService;
    private readonly RepositoryDbContext _repository;
    public LoginService(RepositoryDbContext repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(RegisterLoginEmployeeRequest request)
    {
        var term = request.UserNameOrEmail;
        if(request == null) throw new ArgumentNullException(nameof(request));
        var login = await _repository.Employees
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => 
            (x.Email.Equals(term) || x.UserName.Equals(term))
            && x.Password.Equals(request.Password)) ?? throw new ArgumentNullException("This perfil doesn't exist");

        return _tokenService.GenerateToken(login);
    }
}
