using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime? LastUpdate { get; set; }

        public Author Author { get; set; } = new Author();
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
