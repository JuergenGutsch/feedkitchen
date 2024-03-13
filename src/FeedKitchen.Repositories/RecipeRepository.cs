using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Logging;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FeedKitchen.Repositories
{
    public class RecipeRepository : RepositoryBase
    {
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(
            SqlConnection sqlConnection,
            ILogger<RecipeRepository> logger)
            : base(sqlConnection, logger)
        {
            _logger = logger;
        }

        public async Task Save(Recipe recipe)
        {
            _logger.LogDebug("SaveChanges", recipe);

            var result = await Database.ExecuteAsync("UPDATE recipes SET Title=@Title, Description=@Description, LastUpdate=@LastUpdate WHERE Id=@Id", recipe);

            _logger.LogDebug("SaveChanges", result);
        }

        public async Task<Recipe> Load(int recipeId)
        {
            _logger.LogDebug("Load", recipeId);

            var recipe = await Database.QueryFirstAsync<Recipe>("SELECT Id, Title, Description, LastUpdate FROM recipes WHERE Id=@Id", new { Id = recipeId });

            return recipe;
        }

        public async Task<Recipe> Load(string name)
        {
            _logger.LogDebug("Load", name);

            var recipe = await Database.QueryFirstAsync<Recipe>("SELECT Id, Title, Description, LastUpdate FROM recipes WHERE Name=@Name", new { Name = name });

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> LoadAllRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");

            var recipes = await Database.QueryAsync<Recipe>("SELECT Id, Title, Description, LastUpdate FROM recipes ORDER BY LastUpdate DESC");

            return recipes;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _logger.LogDebug("AddRecipe", recipe);

            var result = await Database.ExecuteAsync("INSERT INTO recipes (Title, Description, LastUpdate, AuthorId) VALUES (@Title, @Description, @LastUpdate, @AuthorId) ", recipe);
        }

        public async Task<IEnumerable<Recipe>> LoadActiveRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");

            var recipes = await Database.QueryAsync<Recipe>("SELECT Id, Title, Description, LastUpdate FROM recipes ORDER BY LastUpdate DESC");

            return recipes;
        }
    }
}
