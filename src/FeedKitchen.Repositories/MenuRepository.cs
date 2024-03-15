using FeedKitchen.Entities.Models;
using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Logging;

namespace FeedKitchen.Repositories
{
    public class MenuRepository
    {
        private readonly FeedKitchenDbContext _dbContext;
        private readonly ILogger<MenuRepository> _logger;

        public MenuRepository(
            FeedKitchenDbContext dbContext,
            ILogger<MenuRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<MenuModel>> Menus()
        {
            _logger.LogDebug("LoadActiveRecipes");

            var menus = _dbContext.Menus
                .OrderByDescending(x => x.LastUpdate)
                .Select(x => new MenuModel
                {
                    Id = x.Id,
                    Author = new AuthorModel { Id = x.Author.Id, Name = x.Author.Name, Email = x.Author.Email },
                    Description = x.Description,
                    LastUpdate = x.LastUpdate,
                    Title = x.Title,
                    Url = new Uri(x.Url),
                });

            return menus;
        }

        public async Task StoreFixings(RecipeModel recipe, IEnumerable<FixingModel> ingredients)
        {
            var sql = "INERT INTO Fixings ()";

            throw new NotImplementedException();
        }

        public async Task<MenuModel> Serve(string name)
        {
            throw new NotImplementedException();
        }
    }
}
