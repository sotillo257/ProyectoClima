using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Domain.Entity;
using Domain.Repository;
using Moq;

namespace ApplicationTests.UseCases.Pokedex;

public class GetPokemonByNameHandlerTests
{
    private readonly Mock<IPokedexRepository> _mockPokedexRepository;
    private readonly GetPokemonByNameHandler _handler;

    public GetPokemonByNameHandlerTests()
    {
        _mockPokedexRepository = new Mock<IPokedexRepository>();
        _handler = new GetPokemonByNameHandler(_mockPokedexRepository.Object);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithValidPokemonName_ShouldReturnPokemonByNameResource()
    {
        // Arrange
        var pokemonName = "pikachu";
        var species = "Mouse Pokemon";
        var type = "Electric";
        var id = 25;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(species, result.Species);
        Assert.Equal(type, result.Type);
        Assert.Equal(id, result.Id);
        _mockPokedexRepository.Verify(repo => repo.GetPokemonByNameOrId(pokemonName), Times.Once);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithPokemonId_ShouldReturnCorrectPokemon()
    {
        // Arrange
        var pokemonId = "1";
        var pokemonName = "bulbasaur";
        var species = "Seed Pokemon";
        var type = "Grass/Poison";
        var id = 1;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonId))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonId);

        // Assert
        Assert.Equal(pokemonId, result.Pokemon);
        Assert.Equal(id, result.Id);
        Assert.Equal(species, result.Species);
        Assert.Equal(type, result.Type);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithDifferentPokemon_ShouldReturnCorrectData()
    {
        // Arrange
        var pokemonName = "charizard";
        var species = "Flame Pokemon";
        var type = "Fire/Flying";
        var id = 6;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(species, result.Species);
        Assert.Equal(type, result.Type);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var pokemonName = "pokemoninexistente";
        var expectedMessage = "Pokemon no encontrado";

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ThrowsAsync(new Exception(expectedMessage));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(
            async () => await _handler.GetPokemonByNameOrId(pokemonName)
        );

        Assert.Equal(expectedMessage, exception.Message);
        _mockPokedexRepository.Verify(repo => repo.GetPokemonByNameOrId(pokemonName), Times.Once);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_ShouldCallRepositoryOnce()
    {
        // Arrange
        var pokemonName = "squirtle";
        var species = "Tiny Turtle Pokemon";
        var type = "Water";
        var id = 7;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        _mockPokedexRepository.Verify(
            repo => repo.GetPokemonByNameOrId(pokemonName),
            Times.Once,
            "El repositorio debe ser llamado exactamente una vez"
        );
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithUpperCaseName_ShouldHandleCorrectly()
    {
        // Arrange
        var pokemonName = "MEWTWO";
        var species = "Genetic Pokemon";
        var type = "Psychic";
        var id = 150;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(id, result.Id);
    }

    [Theory]
    [InlineData("pikachu", "Mouse Pokemon", "Electric", 25)]
    [InlineData("bulbasaur", "Seed Pokemon", "Grass/Poison", 1)]
    [InlineData("charmander", "Lizard Pokemon", "Fire", 4)]
    [InlineData("squirtle", "Tiny Turtle Pokemon", "Water", 7)]
    public async Task GetPokemonByNameOrId_WithMultiplePokemon_ShouldReturnCorrectData(
        string pokemonName,
        string species,
        string type,
        int id)
    {
        // Arrange
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(species, result.Species);
        Assert.Equal(type, result.Type);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithDualTypePokemon_ShouldReturnBothTypes()
    {
        // Arrange
        var pokemonName = "gyarados";
        var species = "Atrocious Pokemon";
        var type = "Water/Flying";
        var id = 130;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.Equal(type, result.Type);
        Assert.Contains("/", result.Type.ToString());
    }

    [Fact]
    public async Task GetPokemonByNameOrId_WithLegendaryPokemon_ShouldReturnCorrectData()
    {
        // Arrange
        var pokemonName = "articuno";
        var species = "Freeze Pokemon";
        var type = "Ice/Flying";
        var id = 144;
        var pokedex = Domain.Entity.Pokedex.Create(pokemonName, species, type, id);

        _mockPokedexRepository
            .Setup(repo => repo.GetPokemonByNameOrId(pokemonName))
            .ReturnsAsync(pokedex);

        // Act
        var result = await _handler.GetPokemonByNameOrId(pokemonName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pokemonName, result.Pokemon);
        Assert.Equal(id, result.Id);
        Assert.Equal(species, result.Species);
        Assert.Equal(type, result.Type);
    }
}
