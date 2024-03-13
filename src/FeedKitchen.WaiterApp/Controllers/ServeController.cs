using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedKitchen.Waiter.Extensions;
using FeedKitchen.Repositories;
using System.Threading.Tasks;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.Waiter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServeController : ControllerBase
    {
        private readonly ILogger<ServeController> _logger;
        private readonly MenuRepository _repository;

        public ServeController(
            ILogger<ServeController> logger,
            MenuRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Menu>> Serve(string name)
        {
            _logger.LogInformation($"Serve '{name}'");

            var menu = await _repository.Serve(name);

            return menu;
        }
    }
}
