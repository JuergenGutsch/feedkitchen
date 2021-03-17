using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CodeHollow.FeedReader;
using System;

namespace FeedKitchen.IngredientsBuyer
{
    public class IngredientLoader
    {
        private readonly ILogger<IngredientLoader> _logger;

        public IngredientLoader(
            ILogger<IngredientLoader> logger)
        {
            _logger = logger;
        }

        public async Task<Feed> Load(Uri url)
        {
            _logger.LogDebug($"Load {url}");

            var feed = await FeedReader.ReadAsync(url.ToString());

            return feed;
        }
    }
}