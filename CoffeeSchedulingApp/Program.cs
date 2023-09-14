using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.InventoryModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn =
    new MySqlConnection(builder.Configuration.GetConnectionString("coffeeschedulerdb"));
    conn.Open();
    return conn;
});
builder.Services.AddTransient<ICoffeeRepo, CoffeeRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IInventoryRepo, InventoryRepo>();

builder.Services.AddDistributedMemoryCache(); // This is for in-memory storage, you can use other providers as well.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5); // Set the session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); //uses/calls the session that we setup above

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
