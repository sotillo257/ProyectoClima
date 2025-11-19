using Domain.Entity;

namespace Domain.Repository;

public interface IPokedexRepository
{
    Task<PokedexList> GetPokemonsAsync(int pageNumber, int pageSize);
    Task<Pokedex> GetPokemonByNameOrId(string pokemon);
}