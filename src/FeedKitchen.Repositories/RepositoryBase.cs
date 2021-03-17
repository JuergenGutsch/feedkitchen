using System.Threading.Tasks;
using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FeedKitchen.Repositories
{
    public abstract class RepositoryBase
    {
        private IMongoDatabase _database;

        protected RepositoryBase(IOptions<MongoOptions> mongoOptions)
        {
            MongoOptions = mongoOptions.Value;
        }

        public IMongoDatabase Database
        {
            get
            {
                return GetOrCreateCbClient();
            }
        }

        public MongoOptions MongoOptions { get; }

        public IMongoDatabase GetOrCreateCbClient()
        {
            if (_database == null)
            {
                var username = MongoOptions.MONGODB_USERNAME;
                var password = MongoOptions.MONGODB_PASSWORD;
                var server = MongoOptions.MONGODB_SERVER;
                var database = MongoOptions.MONGODB_DATABASE;
                var connectionString = $"mongodb+srv://{username}:{password}@{server}/test?retryWrites=true&w=majority";
                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(database);

            }
            return _database;
        }
    }
}
