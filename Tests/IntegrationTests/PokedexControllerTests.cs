using System.Net;
using System.Net.Http.Json;
using Domain.Entity;
using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Xunit;

namespace IntegrationTests;

public class PokedexControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public PokedexControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_WithValidPokemonName_ReturnsOkWithPokemonByNameResource()
    {
        // Arrange
        var pokemonName = "pikachu";
        var pokedex = Pokedex.Create(
            pokemon: "pikachu",
            species: "Mouse Pokémon",
            type: "electric",
            id: 25
        );
        _factory.SetupMockPokedexRepository(pokemonName, pokedex);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonName}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<PokemonByNameResource>();
        Assert.NotNull(result);
        Assert.Equal("pikachu", result.Pokemon);
        Assert.Equal(25, result.Id);
    }

    [Fact]
    public async Task Get_WithValidPokemonId_ReturnsOkWithPokemonByNameResource()
    {
        // Arrange
        var pokemonId = "1";
        var pokedex = Pokedex.Create(
            pokemon: "bulbasaur",
            species: "Seed Pokémon",
            type: "grass/poison",
            id: 1
        );
        _factory.SetupMockPokedexRepository(pokemonId, pokedex);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonId}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<PokemonByNameResource>();
        Assert.NotNull(result);
        Assert.Equal("bulbasaur", result.Pokemon);
        Assert.Equal(1, result.Id);
    }

    [Theory]
    [InlineData("charizard", "Flame Pokémon", "fire/flying", 6)]
    [InlineData("mewtwo", "Genetic Pokémon", "psychic", 150)]
    [InlineData("eevee", "Evolution Pokémon", "normal", 133)]
    public async Task Get_WithMultiplePokemon_ReturnsCorrectData(
        string pokemonName,
        string species,
        string type,
        int id)
    {
        // Arrange
        var pokedex = Pokedex.Create(pokemonName, species, type, id);
        _factory.SetupMockPokedexRepository(pokemonName, pokedex);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonName}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<PokemonByNameResource>();
        Assert.NotNull(result);
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task Get_WithNonExistentPokemon_ReturnsInternalServerError()
    {
        // Arrange
        var pokemonName = "nonexistentpokemon";
        var exception = new InvalidOperationException("Pokemon not found");
        _factory.SetupMockPokedexRepositoryException(pokemonName, exception);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonName}");

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task Get_WithHttpRequestException_ReturnsInternalServerError()
    {
        // Arrange
        var pokemonName = "pikachu";
        var exception = new HttpRequestException("Service unavailable");
        _factory.SetupMockPokedexRepositoryException(pokemonName, exception);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonName}");

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Theory]
    [InlineData("25")]
    [InlineData("150")]
    [InlineData("1")]
    public async Task Get_WithDifferentPokemonIds_ReturnsOk(string pokemonId)
    {
        // Arrange
        var id = int.Parse(pokemonId);
        var pokedex = Pokedex.Create(
            pokemon: $"pokemon{id}",
            species: "Test Species",
            type: "test",
            id: id
        );
        _factory.SetupMockPokedexRepository(pokemonId, pokedex);

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonId}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<PokemonByNameResource>();
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task Get_WithEmptyPokemonName_ReturnsNotFound()
    {
        // Arrange
        var pokemonName = "";

        // Act
        var response = await _client.GetAsync($"/Pokedex/{pokemonName}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
