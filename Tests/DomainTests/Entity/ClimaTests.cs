using Domain.Entity;

namespace DomainTests.Entity;

public class ClimaTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        var ciudad = "Madrid";
        var celsius = 25.5;

        // Act
        var clima = new Clima(ciudad, celsius);

        // Assert
        Assert.NotNull(clima);
        Assert.Equal(ciudad, clima.Ciudad);
        Assert.Equal(celsius, clima.Celsius);
    }

    [Fact]
    public void Constructor_WithNullCiudad_ShouldThrowArgumentException()
    {
        // Arrange
        string? ciudad = null;
        var celsius = 25.5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Clima(ciudad!, celsius));
    }

    [Fact]
    public void Constructor_WithEmptyCiudad_ShouldThrowArgumentException()
    {
        // Arrange
        var ciudad = "";
        var celsius = 25.5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Clima(ciudad, celsius));
    }

    [Fact]
    public void Constructor_WithWhiteSpaceCiudad_ShouldThrowArgumentException()
    {
        // Arrange
        var ciudad = "   ";
        var celsius = 25.5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Clima(ciudad, celsius));
    }

    [Fact]
    public void Constructor_WithNegativeTemperature_ShouldCreateInstance()
    {
        // Arrange
        var ciudad = "Moscow";
        var celsius = -15.5;

        // Act
        var clima = new Clima(ciudad, celsius);

        // Assert
        Assert.NotNull(clima);
        Assert.Equal(ciudad, clima.Ciudad);
        Assert.Equal(celsius, clima.Celsius);
    }

    [Fact]
    public void Constructor_WithZeroTemperature_ShouldCreateInstance()
    {
        // Arrange
        var ciudad = "Oslo";
        var celsius = 0.0;

        // Act
        var clima = new Clima(ciudad, celsius);

        // Assert
        Assert.NotNull(clima);
        Assert.Equal(ciudad, clima.Ciudad);
        Assert.Equal(celsius, clima.Celsius);
    }

    [Fact]
    public void Create_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        var ciudad = "Barcelona";
        var temperatura = 28.3;

        // Act
        var clima = Clima.Create(ciudad, temperatura);

        // Assert
        Assert.NotNull(clima);
        Assert.Equal(ciudad, clima.Ciudad);
        Assert.Equal(temperatura, clima.Celsius);
    }

    [Fact]
    public void Create_WithNullCiudad_ShouldThrowArgumentException()
    {
        // Arrange
        string? ciudad = null;
        var temperatura = 20.0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Clima.Create(ciudad!, temperatura));
    }

    [Fact]
    public void Create_WithEmptyCiudad_ShouldThrowArgumentException()
    {
        // Arrange
        var ciudad = "";
        var temperatura = 20.0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Clima.Create(ciudad, temperatura));
    }

    [Theory]
    [InlineData("London", 15.5)]
    [InlineData("Tokyo", 30.0)]
    [InlineData("New York", -5.2)]
    [InlineData("Buenos Aires", 22.8)]
    public void Create_WithDifferentValidValues_ShouldCreateInstances(string ciudad, double temperatura)
    {
        // Act
        var clima = Clima.Create(ciudad, temperatura);

        // Assert
        Assert.NotNull(clima);
        Assert.Equal(ciudad, clima.Ciudad);
        Assert.Equal(temperatura, clima.Celsius);
    }
}
