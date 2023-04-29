using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FeedKitchen.Shared.Options;
using FeedKitchen.Repositories;

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
                    services.Configure<DatabaseOptions>(c =>
                    {
                        c.ConnectionString = hostContext.Configuration.GetValue<string>("ConnectionString");
                    });
                    services.AddSingleton<IngredientLoader>();
                    services.AddSingleton<RecipeRepository>();
                    services.AddHostedService<Worker>();
                });
    }
}
