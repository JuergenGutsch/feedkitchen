using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.Shared.Models;
using FeedKitchen.MenuWaiter.Extensions;

namespace FeedKitchen.MenuWaiter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManuController : ControllerBase
    {       
        private readonly ILogger<ManuController> _logger;

        public ManuController(ILogger<ManuController> logger)
        {
            _logger = logger;
        }

        public ActionResult<object> Atom()
        {
            var recipe = new Recipe();
            var menu = recipe.Cook();

            return menu;
        }
    }
}
