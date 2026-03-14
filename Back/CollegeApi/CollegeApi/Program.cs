using CollegeApi.Models;
using CollegeApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllers();

// Add these two lines to generate Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add this block to serve the Swagger UI in your browser
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.Run();