using FeedKitchen.Entities.Models;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.Repositories
{
    public class IngredientRepository
    {
        private readonly FeedKitchenDbContext _dbContext;
        private readonly ILogger<IngredientRepository> _logger;

        public IngredientRepository(
            FeedKitchenDbContext dbContext,
            ILogger<IngredientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
