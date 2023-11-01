using ChallengeUserAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Data;

public class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> opts) : base(opts) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Role> Roles { get; set; }
}


