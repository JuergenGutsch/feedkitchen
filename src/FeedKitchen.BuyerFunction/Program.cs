using FeedKitchen.Repositories;
using FeedKitchen.Shared.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((services) =>
    {
        services.Configure<DatabaseOptions>(options =>
        {
            options.ConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings:AppConnetionString");
        });

        services.AddSingleton<RecipeRepository>();
    })
    .Build();


host.Run();
