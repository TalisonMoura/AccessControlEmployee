namespace ChallengeUserAccess.Entities;
/// <summary>
/// This is an entiti who represents the  atributes
/// </summary>
public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid EmployeeId { get; private set; }
    protected Role() { }
}
