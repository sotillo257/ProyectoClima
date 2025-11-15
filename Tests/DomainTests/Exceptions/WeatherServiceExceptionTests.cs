using Domain.Exceptions;

namespace DomainTests.Exceptions;

public class WeatherServiceExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessage()
    {
        // Arrange
        var message = "Weather service error occurred";

        // Act
        var exception = new WeatherServiceException(message);

        // Assert
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void Constructor_WithMessage_ShouldHaveNullStatusCode()
    {
        // Arrange
        var message = "Weather service error occurred";

        // Act
        var exception = new WeatherServiceException(message);

        // Assert
        Assert.Null(exception.StatusCode);
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetMessageAndInnerException()
    {
        // Arrange
        var message = "Weather service error occurred";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new WeatherServiceException(message, innerException);

        // Assert
        Assert.Equal(message, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldHaveNullStatusCode()
    {
        // Arrange
        var message = "Weather service error occurred";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new WeatherServiceException(message, innerException);

        // Assert
        Assert.Null(exception.StatusCode);
    }

    [Fact]
    public void Constructor_WithMessageAndStatusCode_ShouldSetMessageAndStatusCode()
    {
        // Arrange
        var message = "Weather service error occurred";
        var statusCode = 500;

        // Act
        var exception = new WeatherServiceException(message, statusCode);

        // Assert
        Assert.Equal(message, exception.Message);
        Assert.Equal(statusCode, exception.StatusCode);
    }

    [Fact]
    public void Constructor_WithMessageStatusCodeAndInnerException_ShouldSetAllProperties()
    {
        // Arrange
        var message = "Weather service error occurred";
        var statusCode = 404;
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new WeatherServiceException(message, statusCode, innerException);

        // Assert
        Assert.Equal(message, exception.Message);
        Assert.Equal(statusCode, exception.StatusCode);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Theory]
    [InlineData(200)]
    [InlineData(400)]
    [InlineData(401)]
    [InlineData(404)]
    [InlineData(500)]
    [InlineData(503)]
    public void Constructor_WithDifferentStatusCodes_ShouldSetStatusCodeCorrectly(int statusCode)
    {
        // Arrange
        var message = "Weather service error occurred";

        // Act
        var exception = new WeatherServiceException(message, statusCode);

        // Assert
        Assert.Equal(statusCode, exception.StatusCode);
    }

    [Fact]
    public void Constructor_WithNegativeStatusCode_ShouldSetStatusCode()
    {
        // Arrange
        var message = "Weather service error occurred";
        var statusCode = -1;

        // Act
        var exception = new WeatherServiceException(message, statusCode);

        // Assert
        Assert.Equal(statusCode, exception.StatusCode);
    }

    [Fact]
    public void Exception_ShouldBeOfTypeException()
    {
        // Arrange
        var message = "Weather service error occurred";

        // Act
        var exception = new WeatherServiceException(message);

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }

    [Fact]
    public void Exception_CanBeCaught_AsBaseException()
    {
        // Arrange
        var message = "Weather service error occurred";
        var statusCode = 500;
        Exception? caughtException = null;

        // Act
        try
        {
            throw new WeatherServiceException(message, statusCode);
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }

        // Assert
        Assert.NotNull(caughtException);
        Assert.IsType<WeatherServiceException>(caughtException);
        var weatherException = caughtException as WeatherServiceException;
        Assert.Equal(statusCode, weatherException!.StatusCode);
    }

    [Fact]
    public void Constructor_WithNullMessage_ShouldCreateException()
    {
        // Arrange
        string? message = null;

        // Act
        var exception = new WeatherServiceException(message!);

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Constructor_WithEmptyMessage_ShouldCreateException()
    {
        // Arrange
        var message = "";

        // Act
        var exception = new WeatherServiceException(message);

        // Assert
        Assert.Equal(message, exception.Message);
    }

    [Theory]
    [InlineData("API rate limit exceeded", 429)]
    [InlineData("Service temporarily unavailable", 503)]
    [InlineData("Invalid API key", 401)]
    [InlineData("City not found in weather service", 404)]
    public void Constructor_WithDifferentMessagesAndStatusCodes_ShouldSetPropertiesCorrectly(
        string message, int statusCode)
    {
        // Act
        var exception = new WeatherServiceException(message, statusCode);

        // Assert
        Assert.Equal(message, exception.Message);
        Assert.Equal(statusCode, exception.StatusCode);
    }
}
