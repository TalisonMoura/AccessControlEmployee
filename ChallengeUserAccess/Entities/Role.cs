namespace ChallengeUserAccess.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    protected Role() { }
}
