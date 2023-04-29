using System.Threading.Tasks;
using FeedKitchen.Shared.Models;
using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Dapper;

namespace FeedKitchen.Repositories
{
    public class RecipeRepository : RepositoryBase
    {
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(
            IOptions<DatabaseOptions> mongoOptions,
            ILogger<RecipeRepository> logger)
        : base(mongoOptions, logger)
        {
            _logger = logger;
        }

        public async Task SaveChanges(Recipe recipe)
        {
            _logger.LogDebug("SaveChanges", recipe);

           var result =  await Database.ExecuteAsync("UPDATE recipes SET ... WHERE ID = @Id", recipe);

            _logger.LogDebug("SaveChanges", result);
        }

        public async Task<Recipe> Load(int recipeId)
        {
            _logger.LogDebug("Load", recipeId);

            var recipe = await Database.QueryFirstAsync<Recipe>("SELECT ... FROM recipes WHERE id = @Id", new { Id = recipeId });

            return recipe;
        }

        public async Task<Recipe> Load(string name)
        {
            _logger.LogDebug("Load", name);

            var recipe = await Database.QueryFirstAsync<Recipe>("SELECT ... FROM recipes WHERE name = @Name", new { Name = name });

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> LoadActiveRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");

            var recipes = await Database.QueryAsync<Recipe>("SELECT ... FROM recipes ORDER BY LastUpdate DESC");

            return recipes;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _logger.LogDebug("AddRecipe", recipe); 
            var result = await Database.ExecuteAsync("INSERT INTO recipes (...) VALUES ... ", recipe);

        }
    }
}
