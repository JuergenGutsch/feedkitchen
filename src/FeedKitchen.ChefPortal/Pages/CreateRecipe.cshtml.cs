using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FeedKitchen.ChefPortal.Pages
{
    public class CreateRecipeModel : PageModel
    {
        [Required]
        [Display(Name = "Title of the Recipe", Description = "This will be the title of your feed.")]
        [BindProperty]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description", Description = "This will be the description of your feed.")]
        [BindProperty]
        public string Description { get; set; }


        private readonly ILogger<IndexModel> _logger;
        private readonly RecipeRepository _recipeRepository;

        public CreateRecipeModel(
            ILogger<IndexModel> logger,
            RecipeRepository recipeRepository
            )
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                await _recipeRepository.AddRecipe(
                      new Recipe
                      {
                          Title = Title,
                          Description = Description,
                          LastUpdate = DateTime.Now,
                          AuthorId = 1
                      });

                RedirectToPage("Index");
            }
        }
    }
}
