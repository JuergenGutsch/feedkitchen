using System;
using System.Threading.Tasks;
using FeedKitchen.Shared.Models;
using FeedKitchen.Shared.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace FeedKitchen.Repositories
{
    public class RecipeRepository : RepositoryBase
    {
        public RecipeRepository(IOptions<MongoOptions> mongoOptions)
        : base(mongoOptions)
        { }

        public async Task SaveChanges(Recipe recipe)
        {
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var filter = Builders<Recipe>.Filter.Eq(r => r.Id, recipe.Id);

            var result = await mongoRecipes.ReplaceOneAsync(filter, recipe);
        }

        public async Task<Recipe> Load(string name)
        {
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var recipe =  mongoRecipes.AsQueryable()
                .Where(x => x.Title == name)
                .FirstOrDefault();

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> LoadActiveRecipes()
        {
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            var queryable = mongoRecipes.AsQueryable()
                .OrderByDescending(x => x.LastUpdate);

            return queryable;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            var mongoRecipes = Database.GetCollection<Recipe>("Recipes");
            await mongoRecipes.InsertOneAsync(recipe);
        }
    }
}
