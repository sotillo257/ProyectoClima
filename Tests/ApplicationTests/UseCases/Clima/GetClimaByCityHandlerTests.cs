using Aplication.UseCases.Clima.GetClimaByCity;
using Domain.Entity;
using Domain.Repository;
using Moq;

namespace ApplicationTests.UseCases.Clima;

public class GetClimaByCityHandlerTests
{
    private readonly Mock<IClimaRepository> _mockClimaRepository;
    private readonly GetClimaByCityHandler _handler;

    public GetClimaByCityHandlerTests()
    {
        _mockClimaRepository = new Mock<IClimaRepository>();
        _handler = new GetClimaByCityHandler(_mockClimaRepository.Object);
    }

    [Fact]
    public async Task GetClimaByCity_WithValidCity_ShouldReturnClimaByCityResource()
    {
        // Arrange
        var ciudad = "Madrid";
        var temperatura = 25.5;
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        var result = await _handler.GetClimaByCity(ciudad);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ciudad, result.Ciudad);
        Assert.Equal(temperatura, result.Temperatura);
        _mockClimaRepository.Verify(repo => repo.GetClimaByCity(ciudad), Times.Once);
    }

    [Fact]
    public async Task GetClimaByCity_WithDifferentTemperatures_ShouldReturnCorrectValues()
    {
        // Arrange
        var ciudad = "Barcelona";
        var temperatura = -5.2;
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        var result = await _handler.GetClimaByCity(ciudad);

        // Assert
        Assert.Equal(temperatura, result.Temperatura);
    }

    [Fact]
    public async Task GetClimaByCity_WithHighTemperature_ShouldReturnCorrectValue()
    {
        // Arrange
        var ciudad = "Sevilla";
        var temperatura = 42.8;
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        var result = await _handler.GetClimaByCity(ciudad);

        // Assert
        Assert.Equal(temperatura, result.Temperatura);
        Assert.Equal(ciudad, result.Ciudad);
    }

    [Fact]
    public async Task GetClimaByCity_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var ciudad = "CiudadInexistente";
        var expectedMessage = "Ciudad no encontrada";

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ThrowsAsync(new Exception(expectedMessage));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(
            async () => await _handler.GetClimaByCity(ciudad)
        );

        Assert.Equal(expectedMessage, exception.Message);
        _mockClimaRepository.Verify(repo => repo.GetClimaByCity(ciudad), Times.Once);
    }

    [Fact]
    public async Task GetClimaByCity_ShouldCallRepositoryOnce()
    {
        // Arrange
        var ciudad = "Valencia";
        var temperatura = 18.3;
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        await _handler.GetClimaByCity(ciudad);

        // Assert
        _mockClimaRepository.Verify(
            repo => repo.GetClimaByCity(ciudad),
            Times.Once,
            "El repositorio debe ser llamado exactamente una vez"
        );
    }

    [Fact]
    public async Task GetClimaByCity_WithZeroTemperature_ShouldReturnCorrectValue()
    {
        // Arrange
        var ciudad = "Oslo";
        var temperatura = 0.0;
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        var result = await _handler.GetClimaByCity(ciudad);

        // Assert
        Assert.Equal(0.0, result.Temperatura);
        Assert.Equal(ciudad, result.Ciudad);
    }

    [Theory]
    [InlineData("Madrid", 25.5)]
    [InlineData("Barcelona", 22.3)]
    [InlineData("Valencia", 28.7)]
    [InlineData("Bilbao", 15.2)]
    public async Task GetClimaByCity_WithMultipleCities_ShouldReturnCorrectData(
        string ciudad,
        double temperatura)
    {
        // Arrange
        var clima = Domain.Entity.Clima.Create(ciudad, temperatura);

        _mockClimaRepository
            .Setup(repo => repo.GetClimaByCity(ciudad))
            .ReturnsAsync(clima);

        // Act
        var result = await _handler.GetClimaByCity(ciudad);

        // Assert
        Assert.Equal(ciudad, result.Ciudad);
        Assert.Equal(temperatura, result.Temperatura);
    }
}
