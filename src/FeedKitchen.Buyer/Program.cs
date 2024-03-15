using FeedKitchen.Buyer;
using FeedKitchen.Entities.Models;
using FeedKitchen.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<FeedKitchenDbContext>(
    options => options.UseSqlServer("sql"),
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Transient);
builder.Services.AddTransient<RecipeRepository>();
builder.Services.AddTransient<MenuRepository>();

// add background worker
builder.Services.AddHostedService<BuyerHostedService>();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Nothing to see here!");

app.Run();
