using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.Shared.Models;
using FeedKitchen.MenuWaiter.Extensions;
using FeedKitchen.Repositories;
using System.Threading.Tasks;

namespace FeedKitchen.MenuWaiter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {       
        private readonly ILogger<MenuController> _logger;
        private readonly RecipeRepository _repository;

        public MenuController(
            ILogger<MenuController> logger,
            RecipeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Serve()
        {
            var recipe = await _repository.Load("ASP.NET Hacker");

            var menu = recipe.Cook();

            return menu;
        }
    }
}
