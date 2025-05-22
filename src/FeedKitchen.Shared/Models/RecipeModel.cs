namespace FeedKitchen.Shared.Models;

public class RecipeModel
{
    public long Id { get; set; } // Changed from int to long
    public string? Title { get; set; }
    public string? Description { get; set; }
    public long AuthorId { get; set; } // Changed from int to long
    public DateTime? LastUpdate { get; set; }

    public AuthorModel Author { get; set; } = new AuthorModel();
    public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
    public ICollection<FixingModel> Fixings { get; set; } = new List<FixingModel>();
}