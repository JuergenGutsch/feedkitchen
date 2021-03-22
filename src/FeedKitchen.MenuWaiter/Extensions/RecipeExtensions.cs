using FeedKitchen.Shared.Models;
using System.Linq;

namespace FeedKitchen.MenuWaiter.Extensions
{
    public static class RecipeExtensions
    {
        public static Menu Cook(this Recipe recipe)
        {
            var menu = new Menu
            {
                Author = recipe.Author,
                Title = recipe.Title,
                Description = recipe.Description,
                Url = recipe.Url,
                LastUpdate = recipe.LastUpdate
            };

            var ingredients = recipe.Ingredients
                .OrderByDescending(x => x.PublishingDate)
                .Take(20)
                .Select(x => x);
            foreach (var ingredient in ingredients)
                menu.Ingredients.Add(ingredient);

            return menu;
        }
    }
}
