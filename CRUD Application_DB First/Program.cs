using CRUD_Application_DB_First.Models;
using Microsoft.EntityFrameworkCore; // Added for UseSqlServer extension method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<MyLocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myDBConnection"))); // Removed BuildServiceProvider usage

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
/*
 var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<MyLocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyLocalDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
{
    "ConnectionStrings": {
        "MyLocalDbConnection": "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;"
      }
}

 
 */