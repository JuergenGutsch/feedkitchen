using FeedKitchen.Entities.Models;
using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.Repositories
{
    public class RecipeRepository
    {
        private readonly FeedKitchenDbContext _dbContext;
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(
            FeedKitchenDbContext dbContext,
            ILogger<RecipeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Save(RecipeModel recipe)
        {
            _logger.LogDebug("SaveChanges", recipe);

            //  var result = await Database.ExecuteAsync("UPDATE recipes SET Title=@Title, Description=@Description, LastUpdate=@LastUpdate WHERE Id=@Id", recipe);

            _logger.LogDebug("SaveChanges", new RecipeModel());
        }

        public async Task<RecipeModel> Load(int recipeId)
        {
            _logger.LogDebug("Load", recipeId);

            //var recipe = await Database.QueryFirstAsync<RecipeModel>("SELECT Id, Title, Description, LastUpdate FROM recipes WHERE Id=@Id", new { Id = recipeId });

            return new RecipeModel();
        }

        public async Task<RecipeModel> Load(string name)
        {
            _logger.LogDebug("Load", name);

            // var recipe = await Database.QueryFirstAsync<RecipeModel>("SELECT Id, Title, Description, LastUpdate FROM recipes WHERE Name=@Name", new { Name = name });

            return new RecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> LoadAllRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");

            //  var recipes = await Database.QueryAsync<RecipeModel>("SELECT Id, Title, Description, LastUpdate FROM recipes ORDER BY LastUpdate DESC");

            return new List<RecipeModel>();
        }

        public async Task AddRecipe(RecipeModel recipe)
        {
            _logger.LogDebug("AddRecipe", recipe);

            //   var result = await Database.ExecuteAsync("INSERT INTO recipes (Title, Description, LastUpdate, AuthorId) VALUES (@Title, @Description, @LastUpdate, @AuthorId) ", recipe);
        }

        public async Task<IEnumerable<RecipeModel>> LoadActiveRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");

            // var recipes = await Database.QueryAsync<RecipeModel>("SELECT Id, Title, Description, LastUpdate FROM recipes ORDER BY LastUpdate DESC");

            return new List<RecipeModel>();
        }
    }
}
