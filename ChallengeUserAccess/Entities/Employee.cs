namespace ChallengeUserAccess.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public bool? IsAdmin { get; set; }
    public virtual Address Address { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime ModifydAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; private set; }
    public List<Role> Roles { get; private set; } = new List<Role>();

    protected Employee() { }
}
