using System.Net;
using System.Net.Http.Json;
using Domain.Entity;
using Domain.Exceptions;
using Aplication.UseCases.Clima.GetClimaByCity;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IntegrationTests;

public class WeatherForecastControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public WeatherForecastControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_WithValidCity_ReturnsOkWithClimaByCityResource()
    {
        // Arrange
        var city = "Madrid";
        var expectedTemperature = 25.5;
        var clima = Clima.Create(city, expectedTemperature);
        _factory.SetupMockClimaRepository(city, clima);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<ClimaByCityResource>();
        Assert.NotNull(result);
        Assert.Equal(city, result.Ciudad);
        Assert.Equal(expectedTemperature, result.Temperatura);
    }

    [Fact]
    public async Task Get_WithEmptyCity_ReturnsBadRequest()
    {
        // Arrange
        var city = "";

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // Empty string results in route not matching
    }

    [Fact]
    public async Task Get_WithNonExistentCity_ReturnsNotFound()
    {
        // Arrange
        var city = "CiudadInexistente";
        var exception = new CityNotFoundException(city);
        _factory.SetupMockClimaRepositoryException(city, exception);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problemDetails);
        Assert.Equal("Ciudad no encontrada", problemDetails.Title);
        Assert.Contains(city, problemDetails.Detail);
    }

    [Fact]
    public async Task Get_WhenWeatherServiceFails_ReturnsServiceUnavailable()
    {
        // Arrange
        var city = "Barcelona";
        var exception = new WeatherServiceException("El servicio de clima no está disponible");
        _factory.SetupMockClimaRepositoryException(city, exception);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.ServiceUnavailable, response.StatusCode);

        var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problemDetails);
        Assert.Equal("Error en el servicio de clima", problemDetails.Title);
    }

    [Fact]
    public async Task Get_WhenWeatherServiceFailsWithStatusCode_ReturnsCorrectStatusCode()
    {
        // Arrange
        var city = "Valencia";
        var customStatusCode = 429; // Too Many Requests
        var exception = new WeatherServiceException("Too many requests", customStatusCode);
        _factory.SetupMockClimaRepositoryException(city, exception);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal((HttpStatusCode)customStatusCode, response.StatusCode);

        var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problemDetails);
        Assert.Equal("Error en el servicio de clima", problemDetails.Title);
    }

    [Fact]
    public async Task Get_WithUnexpectedException_ReturnsInternalServerError()
    {
        // Arrange
        var city = "Sevilla";
        var exception = new InvalidOperationException("Unexpected error");
        _factory.SetupMockClimaRepositoryException(city, exception);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problemDetails);
        Assert.Equal("Error interno del servidor", problemDetails.Title);
    }

    [Theory]
    [InlineData("London", 15.3)]
    [InlineData("Paris", 20.7)]
    [InlineData("Tokyo", 28.9)]
    [InlineData("New York", -5.2)]
    public async Task Get_WithMultipleCities_ReturnsCorrectTemperatures(string city, double temperature)
    {
        // Arrange
        var clima = Clima.Create(city, temperature);
        _factory.SetupMockClimaRepository(city, clima);

        // Act
        var response = await _client.GetAsync($"/WeatherForecast/{city}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<ClimaByCityResource>();
        Assert.NotNull(result);
        Assert.Equal(city, result.Ciudad);
        Assert.Equal(temperature, result.Temperatura);
    }
}
