using FeedKitchen.MenuWaiter.OutputFormatters;
using FeedKitchen.Repositories;
using FeedKitchen.Shared.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace FeedKitchen.MenuWaiter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.OutputFormatters.Add(new Rss2OutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat(
                        "rss2", MediaTypeHeaderValue.Parse("application/rss+xml"));

                    options.OutputFormatters.Add(new Atom1OutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat(
                        "atom1", MediaTypeHeaderValue.Parse("application/atom+xml"));
                });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<MongoOptions>(c =>
            {
                c.MONGO_INITDB_ROOT_USERNAME = Configuration.GetValue<string>("MONGO_INITDB_ROOT_USERNAME");
                c.MONGO_INITDB_ROOT_PASSWORD = Configuration.GetValue<string>("MONGO_INITDB_ROOT_PASSWORD");
                c.ME_CONFIG_MONGODB_ADMINUSERNAME = Configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINUSERNAME");
                c.ME_CONFIG_MONGODB_ADMINPASSWORD = Configuration.GetValue<string>("ME_CONFIG_MONGODB_ADMINPASSWORD");

                c.MONGODB_USERNAME = Configuration.GetValue<string>("MONGODB_USERNAME");
                c.MONGODB_PASSWORD = Configuration.GetValue<string>("MONGODB_PASSWORD");
                c.MONGODB_SERVER = Configuration.GetValue<string>("MONGODB_SERVER");
                c.MONGODB_DATABASE = Configuration.GetValue<string>("MONGODB_DATABASE");
            });
            services.AddSingleton<RecipeRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FeedKitchen.MenuWaiter", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FeedKitchen.MenuWaiter v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
