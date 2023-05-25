using CodeHollow.FeedReader;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.BuyerFunction.Extensions
{
    public static class IngredientExtensions
    {
        public static async Task<Feed> Buy(this Ingredient ingredient)
        {
            var feed = await FeedReader.ReadAsync(ingredient.Url.ToString());

            return feed;
        }       
        
    }
}