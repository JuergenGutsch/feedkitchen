using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime? LastUpdate { get; set; }

        public AuthorModel Author { get; set; } = new AuthorModel();
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public ICollection<FixingModel> Fixings { get; set; } = new List<FixingModel>();
    }
}
