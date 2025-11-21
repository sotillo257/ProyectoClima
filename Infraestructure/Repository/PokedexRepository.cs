using ClassLibrary1.Recursos;
using Domain.Entity;
using Domain.Repository;
using System.Globalization;
using System.Net.Http.Json;

namespace ClassLibrary1.Repository;

public class PokedexRepository(IHttpClientFactory clientFactory) : IPokedexRepository
{
    public async Task<Pokedex> GetPokemonByNameOrId(string pokemon)
    {
        var client = clientFactory.CreateClient();
        client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        using var req = new HttpRequestMessage(HttpMethod.Get, $"pokemon/{pokemon.ToLower()}");
        using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if (!res.IsSuccessStatusCode)
        {
            var body = await res.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET failed {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");
        }
        var pokedexResponse = await res.Content.ReadFromJsonAsync<PokedexDTO>();
        if (pokedexResponse is null)
        {
            // Handle null response appropriately
            throw new Exception("Failed to deserialize Pokemon data");
        }

        var species = pokedexResponse.species.name;
        var type = pokedexResponse.types.FirstOrDefault().type.name;
        var id = pokedexResponse.id;

        return Pokedex.Create(pokemon, species, type, id);
    }

    public async Task<PokedexList> GetPokemonsAsync(int pageNumber, int pageSize)
    {
        var offset = (pageNumber - 1) * pageSize;

        var client = clientFactory.CreateClient();
        client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        using var req = new HttpRequestMessage(HttpMethod.Get, $"pokemon?offset={pageNumber} &limit= {pageSize}");
        using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if (!res.IsSuccessStatusCode)
        {
            var body = await res.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET failed {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");
        }

        var pokemonListResponse = await res.Content.ReadFromJsonAsync<PokemonPageList>();
        if (pokemonListResponse is null)
        {
            throw new Exception("Failed to deserialize Pokemon list data");
        }
        // Aquí deberías mapear la respuesta a una lista de Pokedex

        var pokemonNames = pokemonListResponse.results.Select(x => x.name).ToList();

        return PokedexList.Create(
             pokemonNames,
             pageNumber,
             pageSize,
             pokemonListResponse.count
             );
    }
    public async Task<LocationList> GetLocationsAsync(int pageNumber, int pageSize)
    {
        var offset = (pageNumber - 1) * pageSize;

        var client = clientFactory.CreateClient();
        client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        using var req = new HttpRequestMessage(HttpMethod.Get, $"location?offset={pageNumber}&limit={pageSize}");
        using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if (!res.IsSuccessStatusCode)
        {
            var body = await res.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET failed {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");
        }

        var locationListResponse = await res.Content.ReadFromJsonAsync<PokemonPageList>();
        if (locationListResponse is null)
        {
            throw new Exception("Failed to deserialize Location list data");
        }
        // Aquí deberías mapear la respuesta a una lista de Pokedex

        var locationNames = locationListResponse.results.Select(x => x.name).ToList();

        return LocationList.Create(
             locationNames,
             pageNumber,
             pageSize,
             locationListResponse.count
             );
    }
}

