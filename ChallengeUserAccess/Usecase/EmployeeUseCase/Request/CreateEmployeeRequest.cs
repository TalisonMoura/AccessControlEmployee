namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

public class CreateEmployeeRequest
{
    public string FullName { get; private set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}
