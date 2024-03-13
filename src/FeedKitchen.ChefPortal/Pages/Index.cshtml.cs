using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedKitchen.ChefPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RecipeRepository _recipeRepository;

        public IEnumerable<Recipe> Recipes { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            RecipeRepository recipeRepository
            )
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        public async Task OnGet()
        {
            Recipes = await _recipeRepository.LoadAllRecipes();
        }
    }
}
