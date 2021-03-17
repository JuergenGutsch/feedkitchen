using FeedKitchen.Shared.Models;

namespace FeedKitchen.MenuWaiter.Extensions
{
    public static class RecipeExtensions
    {
        public static Menu Cook(this Recipe recipe)
        {
            return new Menu();
        }
    }
}
