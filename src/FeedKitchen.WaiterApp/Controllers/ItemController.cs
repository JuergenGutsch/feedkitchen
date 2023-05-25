using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace FeedKitchen.WaiterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ServeController> _logger;
        private readonly RecipeRepository _repository;

        public ItemController(
            ILogger<ServeController> logger,
            RecipeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{menuId}/{itemId}/{urlPart}")]
        public async Task<ActionResult<object>> Item(int menuId, int itemId, string urlPart)
        {
            _logger.LogInformation($"Item '{menuId}/{itemId}/{urlPart}'");

            var link = await LoadLink(menuId, itemId);

            if (string.IsNullOrWhiteSpace(link))
            {
                return new NotFoundResult();
            }
            else
            {
                return new RedirectResult(link);
            }
        }

        private async Task<string> LoadLink(int meniId, int itemId)
        {
            string link = string.Empty;

            var recipe = await _repository.Load(meniId);
            if (recipe is not null)
            {
                var item = recipe.Ingredients.Where(x => x.Id == itemId).FirstOrDefault();
                if (item is not null)
                {
                    link = item.Url?.ToString();
                }
            }

            return link;
        }
    }
}
