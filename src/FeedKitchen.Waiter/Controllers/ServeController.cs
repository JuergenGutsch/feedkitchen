using FeedKitchen.Repositories;
using FeedKitchen.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedKitchen.Waiter.Controllers;

[ApiController]
[Route("[controller]")]
public class ServeController(
    ILogger<ServeController> _logger,
    MenuRepository _repository)
    : ControllerBase
{
    [HttpGet("{name}")]
    public async Task<ActionResult<MenuModel>> Serve(string name)
    {
        _logger.LogInformation("Serve '{Name}'", name);

        var menu = await _repository.Serve(name);

        return menu;
    }
}
