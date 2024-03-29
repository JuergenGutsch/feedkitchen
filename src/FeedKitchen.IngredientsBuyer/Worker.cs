using System;
using System.Threading;
using System.Threading.Tasks;
using FeedKitchen.IngredientsBuyer.Extensions;
using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.IngredientsBuyer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IngredientLoader _ingredientLoader;
        private readonly RecipeRepository _recipeRepository;

        public Worker(
            ILogger<Worker> logger,
            IngredientLoader ingredientLoader,
            RecipeRepository recipeRepository)
        {
            _logger = logger;
            _ingredientLoader = ingredientLoader;
            _recipeRepository = recipeRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // var newRecipe = new Recipe
                // {
                //     Url = new Uri("http://asp.net-hacker.rocks/atom.xml"),
                //     LastUpdate = DateTime.Now.AddYears(-2),
                //     Title = "ASP.NET Hacker",
                //     RecipeId = "aspnethacker",
                //     Description = "My blog about ASP.NET, .NET, C# and community",
                //     Author = new Author
                //     {
                //         Email = "juergen@gutsch-online.de",
                //         Name = "Jürgen Gutsch"
                //     }
                // };
                // await _recipeRepository.AddRecipe(newRecipe);


                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    var recipes = await _recipeRepository.LoadActiveRecipes();
                    foreach (var recipe in recipes)
                    {
                        var feed = await _ingredientLoader.Load(recipe.Url);
                        if (recipe.Update(feed))
                        {
                            await _recipeRepository.Save(recipe);
                        }
                    }

                    await Task.Delay(1000 * 60, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}
