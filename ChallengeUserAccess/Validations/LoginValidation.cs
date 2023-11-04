using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Exceptions;
using ChallengeUserAccess.ExtensionFormat;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

namespace ChallengeUserAccess.Validations;

public class LoginValidation : ILoginValidation
{
    public RegisterLoginEmployeeRequest ValidateLoginCredentials(RegisterLoginEmployeeRequest request)
    {
        if (request == null) throw new InvalidObjectException("The parameters cannot be empty");
        if (!StringExtension.PasswordValidate(request.Password)) throw new InvalidObjectException("This is not a valid password type");
        return request;
    }
}
