using Aplication.UseCases.Clima.GetClimaByCity;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoClima.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IGetClimaByCityHandler _getClimaByCityHandler;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IGetClimaByCityHandler getClimaByCityHandler, ILogger<WeatherForecastController> logger)
    {
        _getClimaByCityHandler = getClimaByCityHandler;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene la información del clima actual de una ciudad
    /// </summary>
    /// <param name="city">Nombre de la ciudad</param>
    /// <returns>Información del clima con temperatura en Celsius</returns>
    /// <response code="200">Retorna la información del clima de la ciudad</response>
    /// <response code="400">Si el nombre de la ciudad es inválido</response>
    /// <response code="404">Si no se encuentra la ciudad</response>
    /// <response code="500">Si ocurre un error interno del servidor</response>
    /// <response code="503">Si el servicio externo de clima no está disponible</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [Route("GetWeatherForecast/{city}")]
    [ProducesResponseType(typeof(ClimaByCityResource), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status503ServiceUnavailable)]
    public async Task<ActionResult<ClimaByCityResource>> Get(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            _logger.LogWarning("Intento de consulta con nombre de ciudad vacío");
            throw new ArgumentException("El nombre de la ciudad no puede estar vacío", nameof(city));
        }

        _logger.LogInformation("Consultando clima para la ciudad: {City}", city);
        var result = await _getClimaByCityHandler.GetClimaByCity(city);
        _logger.LogInformation("Clima obtenido exitosamente para {City}: {Temperature}°C", city, result.Temperatura);

        return Ok(result);
    }
}