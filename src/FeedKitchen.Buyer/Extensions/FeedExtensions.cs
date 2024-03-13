using CodeHollow.FeedReader;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.Buyer.Extensions
{
    public static class FeedExtensions
    {
        public static IEnumerable<Fixing> Convert(this Feed feed)
        {
            return feed.Items.Convert();
        }

        public static IEnumerable<Fixing> Convert(this IEnumerable<FeedItem> items)
        {
            foreach (var item in items)
            {
                yield return item.Convert();
            }
        }

        public static Fixing Convert(this FeedItem item)
        {
            return new Fixing
            {
                IngridientId = item.Id,
                Title = item.Title,
                Link = new Uri(item.Link),
                Author = item.Author,
                Categories = item.Categories,
                PublishingDate = item.PublishingDate,
                Content = item.Content,
                Summary = item.Description
            };
        }
    }
}
