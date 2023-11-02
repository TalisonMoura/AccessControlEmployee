using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

namespace ChallengeUserAccess.Contracts;

public interface ILoginService
{
    Task<string> LoginAsync(RegisterLoginEmployeeRequest request);
}
