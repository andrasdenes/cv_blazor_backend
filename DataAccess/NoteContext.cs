using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class NoteContext :DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
