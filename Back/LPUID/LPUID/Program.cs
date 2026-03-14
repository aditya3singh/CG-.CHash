using LPUID.Data;
using LPUID.Repositories;
using LPUID.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Database & Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 2. Dependency Injection for Repository & Service
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllersWithViews();

// Build the application ONLY ONCE
var app = builder.Build();

// --- DATABASE SEEDER EXECUTION ---
// This runs right after the app is built, but before it starts taking web traffic
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbSeeder.SeedData(context);
    }
    catch (Exception ex)
    {
        // Logs an error in the console if the database fails to seed
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// ---------------------------------

// Configure the HTTP request pipeline
app.UseStaticFiles();
app.UseRouting();

// 3. Enable Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the server (Must be the very last line!)
app.Run();