using System;
using FeedKitchen.BuyerFunction.Extensions;
using FeedKitchen.IngredientsBuyer.Extensions;
using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.BuyerFunction
{
    public class IncredientsBuyer
    {
        private readonly ILogger _logger;
        private readonly RecipeRepository _recipeRepository;
        private readonly MenuRepository _menuRepository;

        public IncredientsBuyer(
            ILoggerFactory loggerFactory,
            RecipeRepository recipeRepository,
            MenuRepository menuRepository)
        {
            _logger = loggerFactory.CreateLogger<IncredientsBuyer>();
            _recipeRepository = recipeRepository;
            _menuRepository = menuRepository;
        }

        [Function("IncredientsBuyer")]
        public async Task Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");

            try
            {
                var recipes = await _recipeRepository.LoadActiveRecipes();
                foreach (var recipe in recipes)
                {
                    foreach(var ingredient in recipe.Ingredients)
                    {
                        var feed = await ingredient.Buy();
                        var fixings = feed.Convert();

                        _menuRepository.Cook(recipe, fixings);
                    }


                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "An Error happened");
                return;
            }
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
