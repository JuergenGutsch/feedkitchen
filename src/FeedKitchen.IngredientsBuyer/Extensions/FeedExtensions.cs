using System.Collections.Generic;
using CodeHollow.FeedReader;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.IngredientsBuyer.Extensions
{
    public static class FeedExtensions
    {
        public static IEnumerable<Ingredient> Convert(this Feed feed)
        {
            return feed.Items.Convert();
        }

        public static IEnumerable<Ingredient> Convert(this IEnumerable<FeedItem> items)
        {
            foreach (var item in items)
            {
                yield return item.Convert();
            }
        }

        public static Ingredient Convert(this FeedItem item)
        {
            return new Ingredient(
                item.Title,
                item.Link,
                item.Author,
                item.Categories,
                item.PublishingDate,
                item.Content);
        }
    }
}
