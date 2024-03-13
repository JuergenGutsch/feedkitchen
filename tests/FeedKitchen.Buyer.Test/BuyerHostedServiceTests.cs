using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FeedKitchen.Buyer.Tests
{
    public class BuyerHostedServiceTests
    {
        private readonly Mock<RecipeRepository> _recipeRepositoryMock;
        private readonly Mock<MenuRepository> _menuRepositoryMock;
        private readonly Mock<ILogger<BuyerHostedService>> _loggerMock;

        public BuyerHostedServiceTests()
        {
            var loggerMock = new Mock<ILogger<IngredientRepository>>();

            _recipeRepositoryMock = new Mock<RecipeRepository>((SqlConnection)null, loggerMock.Object);
            _menuRepositoryMock = new Mock<MenuRepository>((SqlConnection)null, loggerMock.Object);
            _loggerMock = new Mock<ILogger<BuyerHostedService>>();
        }

        [Fact]
        public async void DoWork_ShouldCallExpectedMethods()
        {
            // Arrange
            var service = new BuyerHostedService(
                _recipeRepositoryMock.Object, 
                _menuRepositoryMock.Object, 
                _loggerMock.Object);

            // Act
            service.StartAsync(CancellationToken.None);
            await Task.Delay(100); // Allow time for the timer to trigger DoWork

            // Assert
            _recipeRepositoryMock.Verify(r => r.LoadActiveRecipes(), Times.Once);
            _menuRepositoryMock.Verify(m => m.Store(It.IsAny<Recipe>(), It.IsAny<IEnumerable<Fixing>>()), Times.AtLeastOnce);
        }
    }
}
