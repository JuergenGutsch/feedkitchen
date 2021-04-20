using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeedKitchen.Shared.Extensions
{
    public static class HealthCheckBuilderExtensions
    {
        public static IHealthChecksBuilder AddMongoDbCheck(
            this IHealthChecksBuilder builder,
            IConfiguration configuration)
        {
            var username = configuration.GetValue<string>("MONGODB_USERNAME");
            var password = configuration.GetValue<string>("MONGODB_PASSWORD");
            var server = configuration.GetValue<string>("MONGODB_SERVER");
            var database = configuration.GetValue<string>("MONGODB_DATABASE");
            var connectionString = $"mongodb+srv://{username}:{password}@{server}/{database}?retryWrites=true&w=majority";

            builder.AddMongoDb(connectionString, name: "MongoDb");

            return builder;
        }
    }
}
