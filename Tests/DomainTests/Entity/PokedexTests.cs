using Domain.Entity;

namespace DomainTests.Entity;

public class PokedexTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "Pikachu";
        var species = "Mouse Pokemon";
        var type = "Electric";
        var id = 25;

        // Act
        var pokedex = new Pokedex(pokemon, species, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Equal(pokemon, pokedex.Pokemon);
        Assert.Equal(species, pokedex.Species);
        Assert.Equal(type, pokedex.Type);
        Assert.Equal(id, pokedex.Id);
    }

    [Fact]
    public void Constructor_WithNullPokemon_ShouldThrowArgumentException()
    {
        // Arrange
        string? pokemon = null;
        var species = "Mouse Pokemon";
        var type = "Electric";
        var id = 25;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Pokedex(pokemon!, species, type, id));
    }

    [Fact]
    public void Constructor_WithEmptyPokemon_ShouldThrowArgumentException()
    {
        // Arrange
        var pokemon = "";
        var species = "Mouse Pokemon";
        var type = "Electric";
        var id = 25;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Pokedex(pokemon, species, type, id));
    }

    [Fact]
    public void Constructor_WithWhiteSpacePokemon_ShouldThrowArgumentException()
    {
        // Arrange
        var pokemon = "   ";
        var species = "Mouse Pokemon";
        var type = "Electric";
        var id = 25;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Pokedex(pokemon, species, type, id));
    }

    [Fact]
    public void Constructor_WithNullSpecies_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "Pikachu";
        string? species = null;
        var type = "Electric";
        var id = 25;

        // Act
        var pokedex = new Pokedex(pokemon, species!, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Null(pokedex.Species);
    }

    [Fact]
    public void Constructor_WithNullType_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "Pikachu";
        var species = "Mouse Pokemon";
        string? type = null;
        var id = 25;

        // Act
        var pokedex = new Pokedex(pokemon, species, type!, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Null(pokedex.Type);
    }

    [Fact]
    public void Constructor_WithZeroId_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "MissingNo";
        var species = "Unknown";
        var type = "Unknown";
        var id = 0;

        // Act
        var pokedex = new Pokedex(pokemon, species, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Equal(id, pokedex.Id);
    }

    [Fact]
    public void Constructor_WithNegativeId_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "TestMon";
        var species = "Test Species";
        var type = "Test Type";
        var id = -1;

        // Act
        var pokedex = new Pokedex(pokemon, species, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Equal(id, pokedex.Id);
    }

    [Fact]
    public void Create_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        var pokemon = "Charizard";
        var species = "Flame Pokemon";
        var type = "Fire/Flying";
        var id = 6;

        // Act
        var pokedex = Pokedex.Create(pokemon, species, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Equal(pokemon, pokedex.Pokemon);
        Assert.Equal(species, pokedex.Species);
        Assert.Equal(type, pokedex.Type);
        Assert.Equal(id, pokedex.Id);
    }

    [Fact]
    public void Create_WithNullPokemon_ShouldThrowArgumentException()
    {
        // Arrange
        string? pokemon = null;
        var species = "Flame Pokemon";
        var type = "Fire";
        var id = 6;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pokedex.Create(pokemon!, species, type, id));
    }

    [Fact]
    public void Create_WithEmptyPokemon_ShouldThrowArgumentException()
    {
        // Arrange
        var pokemon = "";
        var species = "Flame Pokemon";
        var type = "Fire";
        var id = 6;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pokedex.Create(pokemon, species, type, id));
    }

    [Theory]
    [InlineData("Bulbasaur", "Seed Pokemon", "Grass/Poison", 1)]
    [InlineData("Squirtle", "Tiny Turtle Pokemon", "Water", 7)]
    [InlineData("Mewtwo", "Genetic Pokemon", "Psychic", 150)]
    [InlineData("Eevee", "Evolution Pokemon", "Normal", 133)]
    public void Create_WithDifferentValidValues_ShouldCreateInstances(
        string pokemon, string species, string type, int id)
    {
        // Act
        var pokedex = Pokedex.Create(pokemon, species, type, id);

        // Assert
        Assert.NotNull(pokedex);
        Assert.Equal(pokemon, pokedex.Pokemon);
        Assert.Equal(species, pokedex.Species);
        Assert.Equal(type, pokedex.Type);
        Assert.Equal(id, pokedex.Id);
    }
}
