using FeedKitchen.Shared.Models;
using Microsoft.Extensions.Logging;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FeedKitchen.Repositories
{
    public class MenuRepository : RepositoryBase
    {
        private readonly ILogger<MenuRepository> _logger;

        public MenuRepository(
            SqlConnection sqlConnection,
            ILogger<MenuRepository> logger)
            : base(sqlConnection, logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Menu>> Menus() {

            _logger.LogDebug("LoadActiveRecipes");

            var recipes = await Database.QueryAsync<Menu>("SELECT Id, Title, Description, LastUpdate, Url FROM menus ORDER BY LastUpdate DESC");

            return recipes;
        }

        /// <summary>
        /// Store fixings into the fridge
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Store(Recipe recipe, IEnumerable<Fixing> ingredients)
        {
            throw new NotImplementedException();
        }

        public async Task<Menu> Serve(string name)
        {
            throw new NotImplementedException();
        }
    }
}
