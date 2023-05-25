using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.Repositories
{
    public class IncredientRepository : RepositoryBase
    {
        private readonly ILogger<IncredientRepository> _logger;

        public IncredientRepository(
            IOptions<DatabaseOptions> dbOptions,
            ILogger<IncredientRepository> logger)
            : base(dbOptions, logger)
        {
            _logger = logger;
        }
    }
}
