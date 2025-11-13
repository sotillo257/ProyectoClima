using Domain.Entity;

namespace Domain.Repository;

public interface IPokedexRepository
{
    Task<Pokedex> GetPokemonByNameOrId(string pokemon);
}