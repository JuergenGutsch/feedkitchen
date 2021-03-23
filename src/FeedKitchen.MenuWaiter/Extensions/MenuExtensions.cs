using FeedKitchen.Shared.Extensions;
using FeedKitchen.Shared.Models;
using System;
using System.Linq;
using System.ServiceModel.Syndication;

namespace FeedKitchen.MenuWaiter.Extensions
{
    public static class MenuExtensions
    {

        public static SyndicationFeed Serve(this Menu menu)
        {
            var feed = new SyndicationFeed(
                   menu.Title, menu.Description,
                   menu.Url, menu.Url.ToString(),
                   new DateTimeOffset(menu.LastUpdate ?? DateTime.Now));

            feed.Items = menu.Ingredients.Select(x =>
            {
                var kitschenUri = !string.IsNullOrWhiteSpace(x.KitchenUri) ? new Uri(x.KitchenUri) : new Uri(x.Link);
                var pubDate = new DateTimeOffset(x.PublishingDate ?? DateTime.Now);

                var syndicationItem = new SyndicationItem(x.Title, x.Content, kitschenUri, x.Link, pubDate)
                {
                    Id = x.Id,
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

    }
}
