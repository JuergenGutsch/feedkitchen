var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FeedKitchen_ManagerPortal>("FeedKitchen-ManagerPortal");

builder.AddProject<Projects.FeedKitchen_ChefPortal>("FeedKitchen-ChefPortal");

builder.AddProject<Projects.FeedKitchen_Doorman>("FeedKitchen-Doorman");

builder.AddProject<Projects.FeedKitchen_Waiter>("FeedKitchen-Waiter");

builder.AddProject<Projects.FeedKitchen_Buyer>("FeedKitchen-Buyer");

builder.Build().Run();
