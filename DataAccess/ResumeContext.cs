using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Configuration;

namespace DataAccess
{
    public class ResumeContext : DbContext
    {
        IServiceProvider _sp { get; set; }
        private string ConnectionString { get; set; }

        public ResumeContext(string connectionString, IServiceProvider sp)
        {
            ConnectionString = connectionString;
            _sp = sp;
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var dataAccessConfig = _sp.GetService<DataAccessConfig>();
                optionsBuilder.UseCosmos(dataAccessConfig.AccountEndpoint, dataAccessConfig.AccountKey, dataAccessConfig.DatabaseName);
            }
        }

    }
}
