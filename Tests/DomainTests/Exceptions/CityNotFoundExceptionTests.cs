using Domain.Exceptions;

namespace DomainTests.Exceptions;

public class CityNotFoundExceptionTests
{
    [Fact]
    public void Constructor_WithCityName_ShouldSetCityNameProperty()
    {
        // Arrange
        var cityName = "Madrid";

        // Act
        var exception = new CityNotFoundException(cityName);

        // Assert
        Assert.Equal(cityName, exception.CityName);
    }

    [Fact]
    public void Constructor_WithCityName_ShouldSetCorrectMessage()
    {
        // Arrange
        var cityName = "Barcelona";
        var expectedMessage = $"No se encontró información del clima para la ciudad '{cityName}'";

        // Act
        var exception = new CityNotFoundException(cityName);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void Constructor_WithCityNameAndInnerException_ShouldSetCityNameProperty()
    {
        // Arrange
        var cityName = "Valencia";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new CityNotFoundException(cityName, innerException);

        // Assert
        Assert.Equal(cityName, exception.CityName);
    }

    [Fact]
    public void Constructor_WithCityNameAndInnerException_ShouldSetCorrectMessage()
    {
        // Arrange
        var cityName = "Sevilla";
        var innerException = new Exception("Inner exception message");
        var expectedMessage = $"No se encontró información del clima para la ciudad '{cityName}'";

        // Act
        var exception = new CityNotFoundException(cityName, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void Constructor_WithCityNameAndInnerException_ShouldSetInnerException()
    {
        // Arrange
        var cityName = "Bilbao";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new CityNotFoundException(cityName, innerException);

        // Assert
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void Constructor_WithNullCityName_ShouldCreateException()
    {
        // Arrange
        string? cityName = null;

        // Act
        var exception = new CityNotFoundException(cityName!);

        // Assert
        Assert.Null(exception.CityName);
    }

    [Fact]
    public void Constructor_WithEmptyCityName_ShouldCreateException()
    {
        // Arrange
        var cityName = "";

        // Act
        var exception = new CityNotFoundException(cityName);

        // Assert
        Assert.Equal(cityName, exception.CityName);
    }

    [Theory]
    [InlineData("London")]
    [InlineData("Paris")]
    [InlineData("Tokyo")]
    [InlineData("New York")]
    public void Constructor_WithDifferentCityNames_ShouldSetCorrectProperties(string cityName)
    {
        // Act
        var exception = new CityNotFoundException(cityName);

        // Assert
        Assert.Equal(cityName, exception.CityName);
        Assert.Contains(cityName, exception.Message);
    }

    [Fact]
    public void Exception_ShouldBeOfTypeException()
    {
        // Arrange
        var cityName = "TestCity";

        // Act
        var exception = new CityNotFoundException(cityName);

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }

    [Fact]
    public void Exception_CanBeCaught_AsBaseException()
    {
        // Arrange
        var cityName = "TestCity";
        Exception? caughtException = null;

        // Act
        try
        {
            throw new CityNotFoundException(cityName);
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }

        // Assert
        Assert.NotNull(caughtException);
        Assert.IsType<CityNotFoundException>(caughtException);
    }
}
