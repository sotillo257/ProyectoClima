using Domain.Entity;

namespace Aplication.UseCases.Pokedex.GetPokemonsPaginated;

public interface IGetPokemonsPaginatedHandler
{
    Task<PokemonsPaginatedResource> GetPokemonsPaginated(Pagination pagination);
}
