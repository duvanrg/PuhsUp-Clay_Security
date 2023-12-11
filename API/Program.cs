using System.Reflection;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Agrega esta referencia para OpenApiModels
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

builder.Services.AddAplicationServices();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddDbContext<ApiContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
