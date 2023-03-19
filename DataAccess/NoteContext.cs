using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class NoteContext : DbContext
    {
        public DbSet<Note>? Notes { get; set; }
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Notes");

            modelBuilder.Entity<Note>()
                .HasNoDiscriminator()
                .HasPartitionKey(o=>o.Id)
                .HasKey(o=>o.Id);

            modelBuilder.Entity<Note>()
                .Property(o => o.Id)
                .HasConversion<string>();
        }
    }
}
