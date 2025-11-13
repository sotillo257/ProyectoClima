using System.Net.Http.Json;
using ClassLibrary1.Recursos;
using Domain.Entity;
using Domain.Repository;

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

            return Pokedex.Create(pokemon, pokedexResponse.Pokemon);
        }
    }
