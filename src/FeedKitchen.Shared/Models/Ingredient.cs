using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class Ingredient
    {
        public Ingredient(
            string title, 
            string link, 
            string author, 
            ICollection<string> categories, 
            DateTime? publishingDate, 
            string content)
        {
            Title = title;
            Link = link;
            Author = author;
            Categories = categories;
            PublishingDate = publishingDate;
            Content = content;
        }

        public string Title { get; }
        public string Link { get; }
        public string Author { get; }
        public ICollection<string> Categories { get; }
        public DateTime? PublishingDate { get; }
        public string Content { get; }
    }
}
