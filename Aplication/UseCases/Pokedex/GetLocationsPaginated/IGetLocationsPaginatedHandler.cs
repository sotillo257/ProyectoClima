using Domain.Entity;

namespace Aplication.UseCases.Pokedex.GetLocationsPaginated
{
    public interface IGetLocationsPaginatedHandler
    {
        Task<LocationsPaginatedResource> GetLocationsPaginated(Pagination pagination);
    }
}
