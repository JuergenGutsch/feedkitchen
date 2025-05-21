using FeedKitchen.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FeedKitchen.Waiter.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(
    ILogger<ItemController> _logger,
    RecipeRepository _repository)
    : ControllerBase
{
    [HttpGet("{menuId}/{itemId}/{urlPart}")]
    public async Task<ActionResult<object>> Item(int menuId, int itemId, string urlPart)
    {
        _logger.LogInformation("Item '{MenuId}/{ItemId}/{UrlPart}'", menuId, itemId, urlPart);

        var link = await LoadLink(menuId, itemId, urlPart);

        if (string.IsNullOrWhiteSpace(link))
        {
            return new NotFoundResult();
        }
        else
        {
            return new RedirectResult(link);
        }
    }

    private async Task<string?> LoadLink(int menuId, int itemId, string urlPart)
    {
        var recipe = await _repository.Load(menuId);
        if (recipe is null)
            return string.Empty;

        var item = recipe.Ingredients.FirstOrDefault(x => x.Id == itemId);
        if (item is null)
            return string.Empty;

        var baseUrl = item.Url?.ToString();
        if (string.IsNullOrWhiteSpace(baseUrl))
            return string.Empty;

        if (string.IsNullOrEmpty(urlPart))
            return baseUrl;

        // Append urlPart as a query string, using '?' or '&' as appropriate
        var separator = baseUrl.Contains('?') ? "&" : "?";
        return baseUrl + separator + urlPart;
    }
}
