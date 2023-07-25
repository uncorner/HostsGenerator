
using HostsGenerator.Infrastructure;
using Microsoft.EntityFrameworkCore;
Console.OutputEncoding = System.Text.Encoding.UTF8;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("Cannot get connection string");

builder.Services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddCustomServices();

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

app.UseRouting();

app.UseAuthorization();

SetRoutes(app);

app.Run();

static void SetRoutes(WebApplication app)
{
    app.MapControllerRoute(
        name: "add_host",
        pattern: "addhost",
        defaults: new { controller = "HostItem", action = "Create" });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}