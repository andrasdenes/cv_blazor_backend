using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class ResumeContext : DbContext
    {
        private DbSet<Job> Jobs { get; set; }

        public ResumeContext()
        { 
        }
    }
}
