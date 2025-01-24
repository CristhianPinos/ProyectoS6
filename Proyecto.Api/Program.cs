using Microsoft.EntityFrameworkCore;
using Proyecto.Persistence;
using System;

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar el servicio de DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

// Este ejemplo llamado WeatherForecast venia dentro del Progam por defecto, lo voy a dejar pero de
// ser necesario para hacer alguna prueba de algo puede borrarlo
app.MapGet("/weatherforecast", () =>
{
var summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

var forecast = Enumerable.Range(1, 5).Select(index =>
    new WeatherForecast
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
    ))
    .ToArray();

return forecast;
});

app.Run();

// La clase del ejemplo del WeatherForecast
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}