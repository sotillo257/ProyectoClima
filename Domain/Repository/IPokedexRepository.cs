using Domain.Entity;

namespace Domain.Repository;

public interface IPokedexRepository
{
    Task<PokedexList<Pokedex>> GetPokemonsPaginated(Pagination pagination);
    Task<Pokedex> GetPokemonByNameOrId(string pokemon);
    Task<int> GetTotalPokemonCount();
}