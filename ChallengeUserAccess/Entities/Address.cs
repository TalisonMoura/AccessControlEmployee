namespace ChallengeUserAccess.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Patio { get; set; }
    public int Number { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime ModifydAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; private set; }
    public Guid EmployeeId { get; private set; }
    protected Address() { }
}
