using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess
{
    public class DIProvider
    {
        public IServiceProvider ServiceProvider { get; init; }

        public DIProvider()
        {
            ServiceProvider = SetupServices();
        }

        protected ServiceProvider SetupServices()
        { 
            var collection = new ServiceCollection();
            
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddUserSecrets(Assembly.GetEntryAssembly()?.GetName().Name);
            configurationBuilder.AddEnvironmentVariables();
            var configuration = configurationBuilder.Build();

            collection.Configure<DataAccessConfig>(configuration);

            collection.AddDbContext<JobContext>(
                    options => options.UseCosmos(
                        configuration["CosmosDb:AccountEndpoint"], 
                        configuration["CosmosDb:AccountKey"], 
                        configuration["CosmosDb:DatabaseName"]
                        )
            );

            return collection.BuildServiceProvider();
        }
    }
}
