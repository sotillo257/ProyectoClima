using System.Net;
using System.Net.Http.Json;
using ClassLibrary1.Configuration;
using ClassLibrary1.Recursos;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Microsoft.Extensions.Options;

namespace ClassLibrary1.Repository;

public class ClimaRepository(IHttpClientFactory clientFactory, IOptions<OpenWeatherMapOptions> options) : IClimaRepository
{
    private readonly OpenWeatherMapOptions _options = options.Value;

    public async Task<Clima> GetClimaByCity(string ciudad)
    {
        try
        {
            var client = clientFactory.CreateClient();
            client.BaseAddress = new Uri(_options.BaseUrl);
            using var req = new HttpRequestMessage(HttpMethod.Get, $"data/2.5/weather?q={ciudad}&appid={_options.ApiKey}&units=metric");
            using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

            if (!res.IsSuccessStatusCode)
            {
                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new CityNotFoundException(ciudad);
                }

                var body = await res.Content.ReadAsStringAsync();
                throw new WeatherServiceException(
                    $"Error al obtener información del clima: {res.ReasonPhrase}",
                    (int)res.StatusCode);
            }

            var climaResponse = await res.Content.ReadFromJsonAsync<ClimaDTO>();

            if (climaResponse?.Main == null)
            {
                throw new WeatherServiceException("La respuesta del servicio de clima no contiene datos válidos");
            }

            return Clima.Create(ciudad, climaResponse.Main.Temp);
        }
        catch (CityNotFoundException)
        {
            throw;
        }
        catch (WeatherServiceException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new WeatherServiceException("Error de conexión con el servicio de clima", ex);
        }
        catch (Exception ex)
        {
            throw new WeatherServiceException("Error inesperado al obtener información del clima", ex);
        }
    }
}