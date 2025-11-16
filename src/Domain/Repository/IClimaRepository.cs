using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Repository;

public interface IClimaRepository
{
    Task<Clima> GetClimaByCity(string ciudad);
}