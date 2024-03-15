using CodeHollow.FeedReader;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.Buyer.Extensions
{
    public static class IngredientExtensions
    {
        public static async Task<IEnumerable<FixingModel>> Buy(this IngredientModel ingredient, RecipeModel reipe)
        {
            var feed = await FeedReader.ReadAsync(ingredient.Url.ToString());

            return feed.Convert(reipe.Id);
        }       
        
    }
}