using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Entities;
using UserRegistration.Infra.Mappings;

namespace UserRegistration.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
