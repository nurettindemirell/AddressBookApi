using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SE4458 Assignment 2 API",
        Version = "v1",
        Description = "Address Book REST API (in-memory) for SE4458 Assignment 2"
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SE4458 Assignment 2 API");
    c.RoutePrefix = string.Empty; // Swagger at root: http://localhost:5149/
});

// Keep HTTPS redirection disabled to avoid port confusion during local dev
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
