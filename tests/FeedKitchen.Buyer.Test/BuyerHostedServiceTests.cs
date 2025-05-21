using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FeedKitchen.Buyer.Tests;

public class BuyerHostedServiceTests
{
    private readonly RecipeRepository _recipeRepositorySub;
    private readonly MenuRepository _menuRepositorySub;
    private readonly ILogger<BuyerHostedService> _loggerSub;

    public BuyerHostedServiceTests()
    {
        var loggerSub = Substitute.For<ILogger<IngredientRepository>>();

        _recipeRepositorySub = Substitute.For<RecipeRepository>((SqlConnection)null, loggerSub);
        _menuRepositorySub = Substitute.For<MenuRepository>((SqlConnection)null, loggerSub);
        _loggerSub = Substitute.For<ILogger<BuyerHostedService>>();
    }

    [Fact]
    public async Task DoWork_ShouldCallExpectedMethods()
    {
        // Arrange
        var service = new BuyerHostedService(
            _recipeRepositorySub,
            _menuRepositorySub,
            _loggerSub);

        // Act
        await service.StartAsync(CancellationToken.None);
        await Task.Delay(100); // Allow time for the timer to trigger DoWork

        // Assert
        await _recipeRepositorySub.Received(1).LoadActiveRecipes();
        await _menuRepositorySub.ReceivedWithAnyArgs().StoreFixings(default, default);
    }
}
