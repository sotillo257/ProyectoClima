using Domain.Repository;

namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public class GetPokemonByNameHandler(IPokedexRepository pokedexRepository) : IGetPokemonByNameHandler
{
    public async Task<PokemonByNameResource> GetPokemonByNameOrId(string pokemon)
    {
        var pokedex = await pokedexRepository.GetPokemonByNameOrId(pokemon);

        return new PokemonByNameResource(pokemon, pokedex.Species, pokedex.Type, pokedex.Id);
    }

}