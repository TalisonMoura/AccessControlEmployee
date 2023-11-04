using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

namespace ChallengeUserAccess.Contracts
{
    public interface ILoginValidation
    {
        RegisterLoginEmployeeRequest ValidateLoginCredentials(RegisterLoginEmployeeRequest request);
    }
}
