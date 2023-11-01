using ChallengeUserAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeUserAccess.Data
{
    public class Repository : DbContext
    {

        public Repository(DbContextOptions<Repository> opts) : base(opts) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
