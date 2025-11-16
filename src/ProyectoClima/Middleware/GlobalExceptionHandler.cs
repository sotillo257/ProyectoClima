using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProyectoClima.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = exception switch
        {
            CityNotFoundException cityNotFound => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Ciudad no encontrada",
                Detail = cityNotFound.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Instance = httpContext.Request.Path,
                Extensions = { ["cityName"] = cityNotFound.CityName }
            },
            WeatherServiceException weatherService => new ProblemDetails
            {
                Status = weatherService.StatusCode ?? StatusCodes.Status503ServiceUnavailable,
                Title = "Error en el servicio de clima",
                Detail = weatherService.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4",
                Instance = httpContext.Request.Path
            },
            ArgumentException argumentException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Solicitud inválida",
                Detail = argumentException.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Instance = httpContext.Request.Path
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Error interno del servidor",
                Detail = "Ocurrió un error inesperado. Por favor, intente nuevamente más tarde.",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Instance = httpContext.Request.Path
            }
        };

        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
