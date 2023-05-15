using HostsGenerator.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostsGenerator.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HostItem> HostItems { get; set; } = null!;
        //public DbSet<HostItems> HostItems => Set<User>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
