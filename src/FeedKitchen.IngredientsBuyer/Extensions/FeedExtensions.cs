﻿using System;
using System.Collections.Generic;
using CodeHollow.FeedReader;
using CodeHollow.FeedReader.Feeds;
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
            var id = Guid.NewGuid().ToString("N");
            return new Ingredient
            {
                Id = id,
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
