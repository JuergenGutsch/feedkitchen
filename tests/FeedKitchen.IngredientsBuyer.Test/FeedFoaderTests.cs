using Xunit;
using System;
using FeedKitchen.IncredientsBuyerFunction.Extensions;
using FeedKitchen.Shared.Models;
using System.Threading.Tasks;

namespace FeedKitchen.IngredientsBuyer.Test
{
    public class FeedLoaderTests
    {
        [Fact]
        public async Task LoadAtomTest()
        {
            var ingredient = new Ingredient
            {
                Url = new Uri("http://asp.net-hacker.rocks/atom.xml")
            };

            var feed = await IngredientExtensions.Buy(ingredient);


            Assert.Equal("ASP.NET Hacker", feed.Title);
        }
    }
}
