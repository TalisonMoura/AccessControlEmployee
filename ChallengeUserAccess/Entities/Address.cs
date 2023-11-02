namespace ChallengeUserAccess.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Patio { get; set; }
    public int Number { get; set; }
    public Guid EmployeeId { get; private set; }
    protected Address() { }
}
