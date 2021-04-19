using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.Repositories;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq;

namespace FeedKitchen.MenuWaiter.Controllers
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
        public async Task<ActionResult<object>> Item(string menuId, string itemId, string urlPart)
        {
            _logger.LogInformation($"Item '{menuId}/{itemId}/{urlPart}'");

            var menuObjectId = new ObjectId(menuId);
            var link = await LoadLink(menuObjectId, itemId);

            if (string.IsNullOrWhiteSpace(link))
            {
                return new NotFoundResult();
            }
            else
            {
                return new RedirectResult(link);
            }
        }

        private async Task<string> LoadLink(ObjectId menuObjectId, string itemId)
        {
            string link = string.Empty;

            var recipe = await _repository.Load(menuObjectId);
            if (recipe is not null)
            {
                var item = recipe.Ingredients.Where(x => x.Id == itemId).FirstOrDefault();
                if (item is not null)
                {
                    link = item.Link?.ToString();
                }
            }

            return link;
        }
    }
}
