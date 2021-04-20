using FeedKitchen.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeedKitchen.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoOptions>(c =>
            {
                c.MONGO_INITDB_ROOT_USERNAME = configuration.GetValue<string>("MONGO_INITDB_ROOT_USERNAME");
                c.MONGO_INITDB_ROOT_PASSWORD = configuration.GetValue<string>("MONGO_INITDB_ROOT_PASSWORD");
                c.ME_CONFIG_MONGODB_ADMINUSERNAME = configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINUSERNAME");
                c.ME_CONFIG_MONGODB_ADMINPASSWORD = configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINPASSWORD");

                c.MONGODB_USERNAME = configuration.GetValue<string>("MONGODB_USERNAME");
                c.MONGODB_PASSWORD = configuration.GetValue<string>("MONGODB_PASSWORD");
                c.MONGODB_SERVER = configuration.GetValue<string>("MONGODB_SERVER");
                c.MONGODB_DATABASE = configuration.GetValue<string>("MONGODB_DATABASE");
            });

            return services;
        }
    }
}
