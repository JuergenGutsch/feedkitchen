using System.Threading.Tasks;
using FeedKitchen.Shared.Models;
using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace FeedKitchen.Repositories
{
    public class MenuRepository : RepositoryBase
    {
        private readonly ILogger<MenuRepository> _logger;

        public MenuRepository(
            IOptions<DatabaseOptions> dbOptions,
            ILogger<MenuRepository> logger)
            : base(dbOptions, logger)
        {
            _logger = logger;
        }

        public void Cook(Recipe recipe, IEnumerable<Fixing> ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> Serve(string name)
        {
            throw new NotImplementedException();
        }
    }
}
