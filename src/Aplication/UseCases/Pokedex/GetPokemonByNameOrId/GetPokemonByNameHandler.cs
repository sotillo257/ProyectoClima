using Domain.Repository;
using System.Threading.Tasks;

namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public class GetPokemonByNameHandler(IPokedexRepository pokedexRepository) : IGetPokemonByNameHandler
{
    public async Task<PokemonByNameResource> GetPokemonByNameOrId(string pokemon)
    {
        var pokedex = await pokedexRepository.GetPokemonByNameOrId(pokemon);

        return new PokemonByNameResource(pokedex.Pokemon, pokedex.Species, pokedex.Type, pokedex.Id);
    }
}