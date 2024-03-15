using CodeHollow.FeedReader;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.Buyer.Extensions
{
    public static class FeedExtensions
    {
        public static IEnumerable<FixingModel> Convert(this Feed feed, int recipeId)
        {
            return feed.Items.Convert(recipeId);
        }

        public static IEnumerable<FixingModel> Convert(this IEnumerable<FeedItem> items, int recipeId)
        {
            foreach (var item in items)
            {
                yield return item.Convert(recipeId);
            }
        }

        public static FixingModel Convert(this FeedItem item, int recipeId)
        {
            return new FixingModel
            {
                Title = item.Title,
                Link = new Uri(item.Link),
                Author = item.Author,
                Categories = item.Categories,
                PublishingDate = item.PublishingDate,
                Content = item.Content,
                Summary = item.Description,
            };
        }
    }
}
