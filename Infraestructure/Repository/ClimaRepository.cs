using System.Net.Http.Json;
using ClassLibrary1.Recursos;
using Domain.Entity;
using Domain.Repository;

namespace ClassLibrary1.Repository;

public class ClimaRepository(IHttpClientFactory clientFactory) : IClimaRepository
{
    private const string AppId = "94d04cc96c9e1a34defaee9a7f6bda66";
    
    public async Task<Clima> GetClimaByCity(string ciudad)
    {
        var client = clientFactory.CreateClient();
        client.BaseAddress = new Uri("https://api.openweathermap.org/");
        using var req = new HttpRequestMessage(HttpMethod.Get, $"data/2.5/weather?q={ciudad}&appid={AppId}&units=metric");
        using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if(!res.IsSuccessStatusCode)
        {
            var body = await res.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET failed {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");
        }
        var climaResponse = await res.Content.ReadFromJsonAsync<ClimaDTO>();

        if (climaResponse?.Main == null)
        {
            throw new InvalidOperationException("La respuesta de la API no contiene información de temperatura.");
        }

        return Clima.Create(ciudad, climaResponse.Main.Temp);
    }
}