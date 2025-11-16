using Aplication.UseCases.Clima.GetClimaByCity;
using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using ClassLibrary1.Configuration;
using ClassLibrary1.Repository;
using Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure OpenWeatherMap options
builder.Services.Configure<OpenWeatherMapOptions>(
    builder.Configuration.GetSection(OpenWeatherMapOptions.SectionName));

builder.Services.AddScoped<IClimaRepository, ClimaRepository>();
builder.Services.AddScoped<IGetClimaByCityHandler, GetClimaByCityHandler>();
builder.Services.AddHttpClient<ClimaRepository>(c =>
{
    c.BaseAddress = new Uri("https://api.openweathermap.org/");
    c.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
});

// Configure Problem Details for error handling
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ProyectoClima.Middleware.GlobalExceptionHandler>();


builder.Services.AddScoped<IPokedexRepository, PokedexRepository>();
builder.Services.AddScoped<IGetPokemonByNameHandler, GetPokemonByNameHandler>();
builder.Services.AddHttpClient<PokedexRepository>(c =>
{
    c.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    c.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Make the implicit Program class public for integration tests
public partial class Program { }