using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FeedKitchen.Shared.Options;
using FeedKitchen.Repositories;
using MongoDB.Bson.Serialization;
using FeedKitchen.Shared.Models;
using FeedKitchen.Shared.Extensions;

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

                    services.AddMongoOptions(hostContext.Configuration);
                    services.AddSingleton<RecipeRepository>();
                    services.AddSingleton<IngredientLoader>();
                    services.AddSingleton<RecipeRepository>();
                    services.AddHostedService<Worker>();

                    //services.AddHealthChecks();
                });
    }
}
