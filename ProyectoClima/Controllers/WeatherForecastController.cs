using Aplication.GetClimaByCity;
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

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("GetWeatherForecast/{city}")]
    public async Task<ClimaByCityResource> Get(string city)
    {
        return await _getClimaByCityHandler.GetClimaByCity(city);
    }
}