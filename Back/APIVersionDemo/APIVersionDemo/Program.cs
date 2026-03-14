using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Scalar.AspNetCore; // <-- 1. Add this using statement

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// .NET 9 built-in OpenAPI generation (No Swashbuckle needed)
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddMvc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // 2. Add this line to enable the visual UI
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();