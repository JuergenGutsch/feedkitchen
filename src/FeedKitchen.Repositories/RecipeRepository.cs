using FeedKitchen.Entities.Models;
using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace FeedKitchen.Repositories;

public class RecipeRepository
{
    private readonly FeedKitchenDbContext _dbContext;
    private readonly ILogger<RecipeRepository> _logger;

    public RecipeRepository(
        FeedKitchenDbContext dbContext,
        ILogger<RecipeRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Save(RecipeModel recipe)
    {
        _logger.LogDebug("Saving (update) recipe with Id={RecipeId}, Title={Title}", recipe.Id, recipe.Title);

        var entity = await _dbContext.Recipes
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == recipe.Id);

        if (entity is null)
        {
            _logger.LogWarning("Recipe with Id={RecipeId} not found for update.", recipe.Id);
            return;
        }

        // Update main properties
        entity.Title = recipe.Title;
        entity.Description = recipe.Description;
        entity.AuthorId = recipe.AuthorId;
        entity.LastUpdate = recipe.LastUpdate ?? DateTime.UtcNow;

        // Update Ingredients
        var modelIngredientIds = recipe.Ingredients.Select(i => i.Id).ToHashSet();

        // Remove ingredients not in the model
        var ingredientsToRemove = entity.Ingredients
            .Where(ei => !modelIngredientIds.Contains(ei.Id))
            .ToList();
        foreach (var ing in ingredientsToRemove)
        {
            entity.Ingredients.Remove(ing);
        }

        // Update or add ingredients
        foreach (var modelIng in recipe.Ingredients)
        {
            var existingIng = entity.Ingredients.FirstOrDefault(ei => ei.Id == modelIng.Id);
            if (existingIng != null)
            {
                existingIng.Name = modelIng.Title;
                existingIng.Url = modelIng.Url?.ToString();
            }
            else
            {
                entity.Ingredients.Add(new Ingredient
                {
                    Name = modelIng.Title,
                    Url = modelIng.Url?.ToString()
                });
            }
        }

        await _dbContext.SaveChangesAsync();

        _logger.LogDebug("SaveChanges (update) completed for recipe with Id={RecipeId}", entity.Id);
    }

    public async Task<RecipeModel> Load(long recipeId)
    {
        _logger.LogDebug("Loading recipe with Id={RecipeId}", recipeId);

        var recipe = await _dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Author)
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == recipeId);

        if (recipe is null)
            return null!;

        return new RecipeModel
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            AuthorId = recipe.AuthorId,
            LastUpdate = recipe.LastUpdate,
            Author = recipe.Author != null
                ? new AuthorModel
                {
                    Id = recipe.Author.Id,
                    Name = recipe.Author.Name,
                    Email = recipe.Author.Email
                }
                : new AuthorModel(),
            Ingredients = recipe.Ingredients?
                .Select(i => new IngredientModel
                {
                    Id = i.Id,
                    Title = i.Name,
                    Url = new Uri(i.Url)
                }).ToList() ?? new List<IngredientModel>()
        };
    }

    public async Task<RecipeModel> Load(string name)
    {
        _logger.LogDebug("Loading recipe with Title={Title}", name);

        var recipe = await _dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Author)
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Title.Contains(name));

        if (recipe is null)
            return null!;

        return new RecipeModel
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            AuthorId = recipe.AuthorId,
            LastUpdate = recipe.LastUpdate,
            Author = recipe.Author != null
                ? new AuthorModel
                {
                    Id = recipe.Author.Id,
                    Name = recipe.Author.Name,
                    Email = recipe.Author.Email
                }
                : new AuthorModel(),
            Ingredients = recipe.Ingredients?
                .Select(i => new IngredientModel
                {
                    Id = i.Id,
                    Title = i.Name,
                    Url = new Uri(i.Url)
                }).ToList() ?? new List<IngredientModel>()
        };
    }

    public async Task<IEnumerable<RecipeModel>> LoadAllRecipes()
    {
        _logger.LogDebug("Loading all recipes");

        var recipes = await _dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Author)
            .Select(r => new RecipeModel
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                AuthorId = r.AuthorId,
                LastUpdate = r.LastUpdate,
                Author = r.Author != null
                    ? new AuthorModel
                    {
                        Id = r.Author.Id,
                        Name = r.Author.Name,
                        Email = r.Author.Email
                    }
                    : new AuthorModel()
                // Optionally map Ingredients, Fixings if needed
            })
            .ToListAsync();

        return recipes;
    }

    public async Task AddRecipe(RecipeModel recipe)
    {
        _logger.LogDebug("Adding recipe with Title={Title}", recipe.Title);

        var authorId = recipe.AuthorId;

        // If AuthorId is not set, try to find or create the author from RecipeModel.Author
        if (authorId == 0 && recipe.Author != null)
        {
            // Try to find an existing author by name and/or email
            var existingAuthor = await _dbContext.Authors
                .FirstOrDefaultAsync(a =>
                    (!string.IsNullOrEmpty(recipe.Author.Email) && a.Email == recipe.Author.Email) ||
                    (!string.IsNullOrEmpty(recipe.Author.Name) && a.Name == recipe.Author.Name)
                );

            if (existingAuthor != null)
            {
                authorId = existingAuthor.Id;
            }
            else
            {
                // Create new author
                var newAuthor = new Author
                {
                    Name = recipe.Author.Name,
                    Email = recipe.Author.Email
                };
                _dbContext.Authors.Add(newAuthor);
                await _dbContext.SaveChangesAsync();
                authorId = newAuthor.Id;
            }
        }

        var entity = new Recipe
        {
            Title = recipe.Title,
            Description = recipe.Description,
            AuthorId = authorId,
            LastUpdate = recipe.LastUpdate ?? DateTime.UtcNow,
            Ingredients = recipe.Ingredients?
                .Select(i => new Ingredient
                {
                    Name = i.Title,
                    Url = i.Url?.ToString()
                }).ToList() ?? new List<Ingredient>()
        };

        _dbContext.Recipes.Add(entity);
        await _dbContext.SaveChangesAsync();

        _logger.LogDebug("Recipe added with generated Id={RecipeId}", entity.Id);
    }

    public async Task<IEnumerable<RecipeModel>> LoadActiveRecipes()
    {
        _logger.LogDebug("Loading active recipes");

        var recipes = await _dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Author)
            // Add any filtering for "active" recipes if needed
            .OrderByDescending(r => r.LastUpdate)
            .Select(r => new RecipeModel
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                AuthorId = r.AuthorId,
                LastUpdate = r.LastUpdate,
                Author = r.Author != null
                    ? new AuthorModel
                    {
                        Id = r.Author.Id,
                        Name = r.Author.Name,
                        Email = r.Author.Email
                    }
                    : new AuthorModel()
                // Optionally map Ingredients, Fixings if needed
            })
            .ToListAsync();

        return recipes;
    }
}
