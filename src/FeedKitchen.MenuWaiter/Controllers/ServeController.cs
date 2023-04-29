using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.MenuWaiter.Extensions;
using FeedKitchen.Repositories;
using System.Threading.Tasks;

namespace FeedKitchen.MenuWaiter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServeController : ControllerBase
    {
        private readonly ILogger<ServeController> _logger;
        private readonly RecipeRepository _repository;

        public ServeController(
            ILogger<ServeController> logger,
            RecipeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<object>> Serve(string name)
        {
            _logger.LogInformation($"Serve '{name}'");

            var recipe = await _repository.Load(name);

            var menu = await recipe.Cook();

            return menu;
        }
    }
}
