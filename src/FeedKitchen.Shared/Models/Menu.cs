using System.Collections.Generic;

namespace FeedKitchen.Shared.Models
{
    public class Menu
    {
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
