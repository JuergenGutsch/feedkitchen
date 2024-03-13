using Xunit;
using System;
using FeedKitchen.Buyer.Extensions;
using FeedKitchen.Shared.Models;
using System.Threading.Tasks;
using FluentAssertions;

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

            var fixings = await IngredientExtensions.Buy(ingredient);

            fixings.Should().NotBeEmpty();
        }
    }
}
