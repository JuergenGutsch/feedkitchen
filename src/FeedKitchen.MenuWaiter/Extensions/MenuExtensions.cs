using FeedKitchen.Shared.Extensions;
using FeedKitchen.Shared.Models;
using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace FeedKitchen.MenuWaiter.Extensions
{
    public static class MenuExtensions
    {
        public static async Task<SyndicationFeed> Serve(this Menu menu)
        {
            var feed = new SyndicationFeed(
                   menu.Title, menu.Description,
                   menu.Url, menu.Url.ToString(),
                   new DateTimeOffset(menu.LastUpdate ?? DateTime.Now));

            feed.Items = menu.Ingredients.Select(x =>
            {
                var kitchenUri = x.SetKitchenUrl(menu.Id);
                var link = x.Link.ToString();
                var pubDate = new DateTimeOffset(x.PublishingDate ?? DateTime.Now);

                var syndicationItem = new SyndicationItem(x.Title, x.Content, kitchenUri, link, pubDate)
                {
                    Id = x.IngridientId,
                    Summary = new TextSyndicationContent(x.Summary, TextSyndicationContentKind.Plaintext),
                    PublishDate = pubDate
                };

                x.Categories.ForEach(y => syndicationItem.Categories.Add(new SyndicationCategory(y)));

                syndicationItem.Authors.Add(new SyndicationPerson
                {
                    Name = x.Author
                });

                return syndicationItem;
            });

            return feed;
        }

        public static Uri SetKitchenUrl(this Ingredient ingredient, int menuId)
        {
            var linkItems = ingredient.Link.Segments;
            var lpathItem = linkItems[linkItems.Length - 1];            
            var kitchenUrl = $"https://localhost:5001/Item/{menuId}/{ingredient.Id}/{lpathItem}";
            return new Uri(kitchenUrl);
        }
    }
}
