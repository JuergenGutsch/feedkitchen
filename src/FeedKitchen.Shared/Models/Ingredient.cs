using System;

namespace FeedKitchen.Shared.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
    }
}