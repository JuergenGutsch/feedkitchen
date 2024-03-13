using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace FeedKitchen.Repositories
{
    public class IngredientRepository : RepositoryBase
    {
        private readonly ILogger<IngredientRepository> _logger;

        public IngredientRepository(
            SqlConnection sqlConnection,
            ILogger<IngredientRepository> logger)
            : base(sqlConnection, logger)
        {
            _logger = logger;
        }
    }
}
