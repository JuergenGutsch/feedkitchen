using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using System;

namespace FeedKitchen.IngredientsBuyer.Test
{
    public class FeedLoaderTests
    {
        [Fact]
        public async void LoadAtomTest()
        {
            var testUri = new Uri("http://asp.net-hacker.rocks/atom.xml");
            var mock = new Mock<ILogger<IngredientLoader>>();

            var logger = mock.Object;
            var sut = new IngredientLoader(logger);

            var feed = await sut.Load(testUri);

            Assert.Equal("ASP.NET Hacker", feed.Title);
        }
    }
}
