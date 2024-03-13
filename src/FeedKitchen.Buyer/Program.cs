using FeedKitchen.Buyer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
// add background worker
builder.Services.AddHostedService<BuyerHostedService>();


var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Nothing to see here!");

app.Run();
