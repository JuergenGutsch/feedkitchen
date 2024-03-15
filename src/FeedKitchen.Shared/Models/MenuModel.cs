using System;
using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class MenuModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Uri? Url { get; set; }

        public AuthorModel Author { get; set; } = new AuthorModel();
        public RecipeModel Recipe { get; set; } = new RecipeModel();

        public ICollection<FixingModel> Fixings { get; set; } = new List<FixingModel>();
    }
}
