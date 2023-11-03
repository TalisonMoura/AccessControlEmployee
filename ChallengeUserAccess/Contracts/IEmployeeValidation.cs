using ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

namespace ChallengeUserAccess.Contracts;

public interface IEmployeeValidation
{
    CreateEmployeeRequest EmpCreateValidate(CreateEmployeeRequest request);
    UpdateEmployeeRequest EmpUpdateValidate(UpdateEmployeeRequest request);
}
