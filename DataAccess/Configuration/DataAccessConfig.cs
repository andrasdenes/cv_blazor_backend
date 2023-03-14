using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    internal class DataAccessConfig
    {
        public string CosmosDbConnectionString { get; set; }
        public string AccountEndpoint { get; set; }
        public string AccountKey { get; set; }
        public string DatabaseName { get; set; }
    }
}
