var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers(); // This allows your MathController to work
builder.Services.AddOpenApi();     // Keeps OpenAPI support for testing

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 3. Map the controllers so requests know where to go
app.MapControllers();

app.Run();