using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class JobContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultContainer("Jobs");

            modelBuilder.Entity<Job>()
                .HasNoDiscriminator()
                .HasPartitionKey(x => x.Id)
                .HasKey(x => x.Id);

            modelBuilder.Entity<Job>()
                .Property(p => p.Id)
                .HasConversion<string>();
        }
    }
}
