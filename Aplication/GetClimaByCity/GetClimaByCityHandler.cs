using Domain.Repository;

namespace Aplication.GetClimaByCity;

public class GetClimaByCityHandler(IClimaRepository climaRepository) :  IGetClimaByCityHandler
{
    public async Task<ClimaByCityResource> GetClimaByCity(string ciudad)
    {
        var clima = await climaRepository.GetClimaByCity(ciudad);

        return new ClimaByCityResource(ciudad, clima.Celsius);
    }
}