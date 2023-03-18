using System.Reflection;
using DataAccess.Configuration;
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

            collection.Configure<DataAccessConfig>(configurationBuilder.Build());
            return collection.BuildServiceProvider();
        }
    }
}
