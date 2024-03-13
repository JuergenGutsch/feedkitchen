using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace FeedKitchen.Repositories
{
    public abstract class RepositoryBase : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private readonly ILogger _logger;

        protected RepositoryBase(
            SqlConnection sqlConnection,
            ILogger logger)
        {
            _sqlConnection = sqlConnection;
            _logger = logger;
        }

        protected DbConnection Database
        {
            get
            {
                EnsureOpenConnection();
                return _sqlConnection;
            }
        }

        protected void EnsureOpenConnection()
        {
            if (_sqlConnection.State ==  System.Data.ConnectionState.Closed)
            {
                 _sqlConnection.Open();
            }
        }

        public void Dispose()
        {
            if (_sqlConnection != null && _sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }
    }
}
