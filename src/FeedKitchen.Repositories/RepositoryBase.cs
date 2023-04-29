using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Threading.Tasks;

namespace FeedKitchen.Repositories
{
    public abstract class RepositoryBase
    {
        private SqlConnection _connection;

        protected RepositoryBase(
            IOptions<DatabaseOptions> dbOptions,
            ILogger logger)
        {
            DbOptions = dbOptions.Value;
            _logger = logger;
        }

        public DbConnection Database
        {
            get
            {
                return  GetOrCreateCbClient();
            }
        }

        public DatabaseOptions DbOptions { get; }

        private readonly ILogger _logger;

        public DbConnection GetOrCreateCbClient()
        {
            if (_connection == null)
            {
                var connectionString = DbOptions.ConnectionString;
                _logger.LogInformation(connectionString);
                var connection = new SqlConnection(connectionString);
                 connection.Open();
                _connection = connection;
            }
            return _connection;
        }
    }
}
