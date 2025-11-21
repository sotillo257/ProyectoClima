using Domain.Entity;
using Domain.Repository;

namespace Aplication.UseCases.Pokedex.GetLocationsPaginated
{
    public class GetLocationsPaginatedHandler(IPokedexRepository pokedexRepository) : IGetLocationsPaginatedHandler
    {
        public async Task<LocationsPaginatedResource> GetLocationsPaginated(GetLocationPaginatdRequest pagination)
        {
            var pokedex = await pokedexRepository.GetLocationsAsync(pagination.PageNumber, pagination.PageSize);

            if (pagination.SortOrder == "asc")
            {
                pokedex.Location = pokedex.Location.OrderBy(x => x).ToList();
            }
            else if (pagination.SortOrder == "desc")
            {
                pokedex.Location = pokedex.Location.OrderByDescending(x => x).ToList();
            }

            return new LocationsPaginatedResource(pokedex.PageNumber, pokedex.PageSize, pokedex.TotalCount, pokedex.Location, pagination.SortOrder);
        }
    }
}
