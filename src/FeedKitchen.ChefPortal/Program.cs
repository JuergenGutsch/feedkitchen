using FeedKitchen.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//.AddCookie()
//.AddOpenIdConnect(options =>
//{
//    options.SignInScheme = "Cookies";
//    options.Authority = "https://localhost:5000";
//    options.RequireHttpsMetadata = true;
//    options.ClientId = "chef_portal_client";
//    options.ClientSecret = "chef_portal_client_secret";
//    options.ResponseType = "code";
//    options.UsePkce = true;
//    options.Scope.Add("profile");
//    options.Scope.Add("offline_access");
//    options.SaveTokens = true;
//});

builder.Services.AddScoped<RecipeRepository>();

//builder.Services.AddSingleton(new DatabaseOptions
//{
//    ConnectionString = builder.Configuration.GetConnectionString("_DatabaseConnection")
//});

//builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();

app.Run();