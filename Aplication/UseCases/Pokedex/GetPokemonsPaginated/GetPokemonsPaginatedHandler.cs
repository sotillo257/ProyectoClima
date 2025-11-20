using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Domain.Entity;
using Domain.Repository;

namespace Aplication.UseCases.Pokedex.GetPokemonsPaginated
{
    public class GetPokemonsPaginatedHandler(IPokedexRepository pokedexRepository) : IGetPokemonsPaginatedHandler
    {
        public async Task<PokemonsPaginatedResource> GetPokemonsPaginated(Pagination pagination)
        {
            var pokedex = await pokedexRepository.GetPokemonsAsync(pagination.PageNumber, pagination.PageSize);

            // Convertir la lista de nombres a un array si el constructor lo requiere
            return new PokemonsPaginatedResource(pokedex.PageNumber, pokedex.PageSize, pokedex.TotalCount, pokedex.Name);
        }
    }
}
