using Domain.Entity;
using Domain.Repository;

namespace Aplication.UseCases.Pokedex.GetLocationsPaginated
{
    public class GetLocationsPaginatedHandler(IPokedexRepository pokedexRepository) : IGetLocationsPaginatedHandler
    {
        public async Task<LocationsPaginatedResource> GetLocationsPaginated(Pagination pagination)
        {
            var pokedex = await pokedexRepository.GetLocationsAsync(pagination.PageNumber, pagination.PageSize, pagination.SortBy);

        // Convertir la lista de nombres a un array si el constructor lo requiere
            return new LocationsPaginatedResource(pokedex.PageNumber, pokedex.PageSize, pokedex.TotalCount, pokedex.Location, pagination.SortBy, pagination.SortOrder);
        }
    }
}
