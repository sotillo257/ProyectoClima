using Domain.Entity;

namespace Domain.Repository;

public interface IClimaRepository
{
    Task<Clima> GetClimaByCity(string ciudad);
}