using System;
using System.Collections.Generic;
using System.Linq;
using CodeHollow.FeedReader;
using FeedKitchen.Shared.Extensions;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.IngredientsBuyer.Extensions
{
    public static class RecipeExtensions
    {
        public static bool Update(this Recipe recipe, Feed feed)
        {
            var ingredients = feed.Convert();
            var updateCount = recipe.AddNewIngredients(ingredients);
            if (updateCount > 0)
            {
                recipe.LastUpdate = feed.LastUpdatedDate;
                return true;
            }
            return false;
        }

        public static int AddNewIngredients(this Recipe recipe, IEnumerable<Ingredient> ingredients)
        {
            if (recipe.Ingredients == null)
            {
                recipe.Ingredients = new List<Ingredient>();
            }
            var i = 0;
            ingredients
                .Where(x => x.PublishingDate >= recipe.LastUpdate)
                .ForEach(x =>
                {
                    var linkItems = x.Link.Segments;
                    var lpathItem = linkItems[linkItems.Length - 1];
                    var kitchenUrl = $"https://localhost:5001/Item/{recipe.RecipeId}/{x.Id}/{lpathItem}";

                    x.KitchenUri = new Uri(kitchenUrl);

                    recipe.Ingredients.Add(x);
                    i++;
                });
            return i;
        }
    }
}
