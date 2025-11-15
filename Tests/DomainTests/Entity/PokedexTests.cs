using Domain.Entity;

namespace DomainTests.Entity;

public class PokedexTests
{    

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
        Assert.Throws<ArgumentNullException>(() => Pokedex.Create(pokemon!, species, type, id));
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
