using System.Reflection;
using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            var configuration = configurationBuilder.Build();

            collection.Configure<DataAccessConfig>(configuration);

            collection.AddDbContext<NoteContext>(
                options => options.UseCosmos(configuration.GetValue<string>("AccountEndpoint"), configuration.GetValue<string>("AccountKey"), configuration.GetValue<string>("DatabaseName"))
                );

            return collection.BuildServiceProvider();
        }
    }
}
