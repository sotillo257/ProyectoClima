using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Domain.Repository;
using Domain.Entity;
using Moq;

namespace IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public Mock<IClimaRepository> MockClimaRepository { get; }
    public Mock<IPokedexRepository> MockPokedexRepository { get; }

    public CustomWebApplicationFactory()
    {
        MockClimaRepository = new Mock<IClimaRepository>();
        MockPokedexRepository = new Mock<IPokedexRepository>();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the real repository registrations
            services.RemoveAll<IClimaRepository>();
            services.RemoveAll<IPokedexRepository>();

            // Add mock repositories
            services.AddScoped(_ => MockClimaRepository.Object);
            services.AddScoped(_ => MockPokedexRepository.Object);
        });

        builder.UseEnvironment("Testing");
    }

    public void SetupMockClimaRepository(string city, Clima climaResponse)
    {
        MockClimaRepository
            .Setup(repo => repo.GetClimaByCityAsync(city))
            .ReturnsAsync(climaResponse);
    }

    public void SetupMockPokedexRepository(string pokemon, Pokedex pokemonResponse)
    {
        MockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrIdAsync(pokemon))
            .ReturnsAsync(pokemonResponse);
    }

    public void SetupMockClimaRepositoryException(string city, Exception exception)
    {
        MockClimaRepository
            .Setup(repo => repo.GetClimaByCityAsync(city))
            .ThrowsAsync(exception);
    }

    public void SetupMockPokedexRepositoryException(string pokemon, Exception exception)
    {
        MockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrIdAsync(pokemon))
            .ThrowsAsync(exception);
    }
}
