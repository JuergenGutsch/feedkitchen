using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FeedKitchen.Shared.Options;
using FeedKitchen.Repositories;
using MongoDB.Bson.Serialization;
using FeedKitchen.Shared.Models;

namespace FeedKitchen.IngredientsBuyer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    BsonClassMap.RegisterClassMap<Recipe>();
                    BsonClassMap.RegisterClassMap<Ingredient>();

                    services.Configure<MongoOptions>(c =>
                    {
                        c.MONGO_INITDB_ROOT_USERNAME = hostContext.Configuration.GetValue<string>("MONGO_INITDB_ROOT_USERNAME");
                        c.MONGO_INITDB_ROOT_PASSWORD = hostContext.Configuration.GetValue<string>("MONGO_INITDB_ROOT_PASSWORD");
                        c.ME_CONFIG_MONGODB_ADMINUSERNAME = hostContext.Configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINUSERNAME");
                        c.ME_CONFIG_MONGODB_ADMINPASSWORD = hostContext.Configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINPASSWORD");

                        c.MONGODB_USERNAME = hostContext.Configuration.GetValue<string>("MONGODB_USERNAME");
                        c.MONGODB_PASSWORD = hostContext.Configuration.GetValue<string>("MONGODB_PASSWORD");
                        c.MONGODB_SERVER = hostContext.Configuration.GetValue<string>("MONGODB_SERVER");
                        c.MONGODB_DATABASE = hostContext.Configuration.GetValue<string>("MONGODB_DATABASE");
                    });
                    services.AddSingleton<IngredientLoader>();
                    services.AddSingleton<RecipeRepository>();
                    services.AddHostedService<Worker>();
                });
    }
}
