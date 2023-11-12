namespace ChallengeUserAccess.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string Cpf { get; private set; }
    public string FullName { get; private set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime ModifydAt { get; set; } = DateTime.UtcNow;
    public virtual Address Address { get; private set; }
    public List<Role> Roles { get; private set; }

    protected Employee() { }
}
