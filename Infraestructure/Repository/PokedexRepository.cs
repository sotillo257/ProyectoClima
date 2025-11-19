using ClassLibrary1.Recursos;
using Domain.Entity;
using Domain.Repository;
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

    public async Task<List<Pokedex>> GetPokemonsAsync(int pageNumber, int pageSize)
    {
        var offset = (pageNumber - 1) * pageSize;

        var client = clientFactory.CreateClient();
        using var req = new HttpRequestMessage(HttpMethod.Get, $"pokemon?offset={pageNumber}&limit={pageSize}");
        using var res = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if (!res.IsSuccessStatusCode)
        {
            var body = await res.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET failed {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");
        }

        var pokemonListResponse = await res.Content.ReadFromJsonAsync<PokedexDTO>();
        if (pokemonListResponse is null)
        {
            throw new Exception("Failed to deserialize Pokemon list data");
        }
        // Aquí deberías mapear la respuesta a una lista de Pokedex
        var totalCount = pokemonListResponse.Count;
        var name = pokemonListResponse.species.name;
        return new List<Pokedex>(); // Implementación pendiente
    }

    public Task<PokedexList<Pokedex>> GetPokemonsPaginated(Pagination pagination)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalPokemonCount()
    {
        throw new NotImplementedException();
    }
}

