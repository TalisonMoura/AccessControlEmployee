namespace ChallengeUserAccess.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid EmployeeId { get; private set; }
    protected Role() { }
}
