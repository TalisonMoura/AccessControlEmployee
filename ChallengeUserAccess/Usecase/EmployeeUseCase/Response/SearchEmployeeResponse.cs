using ChallengeUserAccess.Entities;

namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Response;

public class SearchEmployeeResponse
{
    public string FullName { get; private set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public virtual Address Address { get; private set; }
}
