var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddConnectionString("sql");

builder.AddProject<Projects.FeedKitchen_ManagerPortal>("FeedKitchen-ManagerPortal")
    .WithReference(database);

builder.AddProject<Projects.FeedKitchen_ChefPortal>("FeedKitchen-ChefPortal")
    .WithReference(database);

builder.AddProject<Projects.FeedKitchen_Doorman>("FeedKitchen-Doorman")
    .WithReference(database);

builder.AddProject<Projects.FeedKitchen_Waiter>("FeedKitchen-Waiter")
    .WithReference(database);

builder.AddProject<Projects.FeedKitchen_Buyer>("FeedKitchen-Buyer")
    .WithReference(database);

builder.Build().Run();
