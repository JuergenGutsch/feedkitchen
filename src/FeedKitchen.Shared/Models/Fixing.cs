using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class Fixing
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Uri? Link { get; set; }
        public Uri? KitchenUri { get; set; }
        public string? Author { get; set; }
        public ICollection<string> Categories { get; set; } = new string[] { };
        public DateTime? PublishingDate { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public string? IngridientId { get; set; }
    }
}