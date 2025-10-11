namespace Aplication.GetClimaByCity;

public interface IGetClimaByCityHandler
{
    Task<ClimaByCityResource> GetClimaByCity(string ciudad);
}