using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Exceptions;
using ChallengeUserAccess.ExtensionFormat;
using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;
using Microsoft.AspNetCore.JsonPatch;

namespace ChallengeUserAccess.Validations;

public class EmployeeValidation : IEmployeeValidation
{
    public CreateEmployeeRequest EmpCreateValidate(CreateEmployeeRequest request)
    {
        if (StringExtension.IsNumberAndLetters(request.FullName)) throw new InvalidObjectException("The name cannot contains numbers");
        if (!StringExtension.PasswordValidate(request.Password)) throw new InvalidObjectException("Password must be (Aa1*) min 8 characters");
        if (!StringExtension.EmailValidate(request.Email)) throw new InvalidObjectException("Email is invalid");
        if (!StringExtension.PhoneNumberValidate(request.PhoneNumber)) throw new InvalidObjectException("This format number is invalid");
        return request;
    }
    public UpdateEmployeeRequest EmpUpdateValidate(UpdateEmployeeRequest request)
    {
        if (request == null) throw new InvalidObjectException("The paramter cannot be empty");
        if (!StringExtension.PasswordValidate(request.Password)) throw new InvalidObjectException("Password must be (Aa1*) min 8 characters");
        if (!StringExtension.EmailValidate(request.Email)) throw new InvalidObjectException("Email is invalid");
        if (!StringExtension.PhoneNumberValidate(request.PhoneNumber)) throw new InvalidObjectException("This format number is invalid");
        return request;
    }
}
