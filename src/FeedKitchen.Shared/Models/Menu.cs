﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class Menu
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Uri Url { get; set; }
        public Author Author { get; set; } = new Author();
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
