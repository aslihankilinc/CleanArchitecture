using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence
{
    public class CleanArcDbContext : DbContext
    {
        public CleanArcDbContext(DbContextOptions<CleanArcDbContext> options)
        : base(options)
        {
        }

        protected CleanArcDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArcDbContext).Assembly);
        }

        public DbSet<Office> Office { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}