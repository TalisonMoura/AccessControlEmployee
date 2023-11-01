namespace ChallengeUserAccess.Entities;

public class EmployeeRole
{
    public Guid Id { get; set; }
    public List<Employee> Employees { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
}
