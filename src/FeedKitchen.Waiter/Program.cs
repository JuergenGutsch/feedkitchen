using FeedKitchen.Repositories;
using FeedKitchen.Shared.Options;
using FeedKitchen.Waiter.OutputFormatters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers()
    .AddMvcOptions(options =>
    {
        options.OutputFormatters.Add(new Rss2OutputFormatter());
        options.FormatterMappings.SetMediaTypeMappingForFormat(
            "rss2", MediaTypeHeaderValue.Parse("application/rss+xml"));

        options.OutputFormatters.Add(new Atom1OutputFormatter());
        options.FormatterMappings.SetMediaTypeMappingForFormat(
            "atom1", MediaTypeHeaderValue.Parse("application/atom+xml"));
    });

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.Configure<DatabaseOptions>(c =>
{
    c.ConnectionString = builder.Configuration.GetValue<string>("ConnectionString");
});
builder.Services.AddScoped<RecipeRepository>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FeedKitchen.MenuWaiter v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();