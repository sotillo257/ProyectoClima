using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Aplication.UseCases.Clima.GetClimaByCity;
using ClassLibrary1.Repository;
using Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IClimaRepository, ClimaRepository>();
builder.Services.AddScoped<IGetClimaByCityHandler, GetClimaByCityHandler>();
builder.Services.AddHttpClient<ClimaRepository>(c =>
{
    c.BaseAddress = new Uri("https://api.openweathermap.org/");
    c.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
});

builder.Services.AddScoped<IPokedexRepository, PokedexRepository>();
builder.Services.AddScoped<IGetPokemonByNameHandler, GetPokemonByNameHandler>();
builder.Services.AddHttpClient<PokedexRepository>(c =>
{
    c.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    c.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();