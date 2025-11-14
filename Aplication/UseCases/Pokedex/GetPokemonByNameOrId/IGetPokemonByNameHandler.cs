namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public interface IGetPokemonByNameHandler
{
    Task<PokemonByNameResource> GetPokemonByNameOrId(string pokemon);
}
