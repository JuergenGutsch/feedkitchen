var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FeedKitchen_ManagerPortal>("feedkitchen.managerportal");

builder.AddProject<Projects.FeedKitchen_ChefPortal>("feedkitchen.chefportal");

builder.AddProject<Projects.FeedKitchen_Doorman>("feedkitchen.doorman");

builder.AddProject<Projects.FeedKitchen_Waiter>("feedkitchen.waiter");

builder.AddProject<Projects.FeedKitchen_Buyer>("feedkitchen.buyer");

builder.Build().Run();
