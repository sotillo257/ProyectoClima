using System.Threading.Tasks;

namespace Aplication.UseCases.Clima.GetClimaByCity;

public interface IGetClimaByCityHandler
{
    Task<ClimaByCityResource> GetClimaByCity(string ciudad);
}