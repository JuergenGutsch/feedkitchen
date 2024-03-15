
using FeedKitchen.Buyer.Extensions;
using FeedKitchen.Repositories;

namespace FeedKitchen.Buyer;

public class BuyerHostedService : IHostedService, IDisposable
{
    private readonly RecipeRepository _recipeRepository;
    private readonly MenuRepository _menuRepository;
    private readonly ILogger<BuyerHostedService> _logger;
    private Timer? _timer = null;

    public BuyerHostedService(
        RecipeRepository recipeRepository,
        MenuRepository menuRepository,
        ILogger<BuyerHostedService> logger)
    {
        _recipeRepository = recipeRepository;
        _menuRepository = menuRepository;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromMinutes(5));
    }

    private async void DoWork(object? state)
    {
        _logger.LogInformation($"Timed Hosted Service executed at: {DateTime.Now}");

        try
        {
            var recipes = await _recipeRepository.LoadActiveRecipes();
            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    var fixings = await ingredient.Buy(recipe);

                   await _menuRepository.StoreFixings(recipe, fixings);
                }
            }
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogError(ex, "An Error happened");
            return;
        }

        _logger.LogInformation($"Timed Hosted Service ended at: {DateTime.Now}");
    }

    public async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}