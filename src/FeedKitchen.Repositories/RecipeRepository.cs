using System;
using System.Threading.Tasks;
using FeedKitchen.Shared.Models;
using FeedKitchen.Shared.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.Repositories
{
    public class RecipeRepository : RepositoryBase
    {
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(
            IOptions<MongoOptions> mongoOptions,
            ILogger<RecipeRepository> logger)
        : base(mongoOptions, logger)
        {
            _logger = logger;
        }

        public async Task SaveChanges(Recipe recipe)
        {
            _logger.LogDebug("SaveChanges", recipe);
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var filter = Builders<Recipe>.Filter.Eq(r => r.Id, recipe.Id);

            var result = await mongoRecipes.ReplaceOneAsync(filter, recipe);
        }

        public async Task<Recipe> Load(string name)
        {
            _logger.LogDebug("Load", name);
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var recipe =  mongoRecipes.AsQueryable()
                .Where(x => x.RecipeId == name)
                .FirstOrDefault();

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> LoadActiveRecipes()
        {
            _logger.LogDebug("LoadActiveRecipes");
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var queryable = mongoRecipes.AsQueryable()
                .OrderByDescending(x => x.LastUpdate);

            return queryable;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _logger.LogDebug("AddRecipe", recipe);
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            await mongoRecipes.InsertOneAsync(recipe);
        }
    }
}
