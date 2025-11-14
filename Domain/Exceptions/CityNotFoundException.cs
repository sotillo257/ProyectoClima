namespace Domain.Exceptions;

public class CityNotFoundException : Exception
{
    public string CityName { get; }

    public CityNotFoundException(string cityName)
        : base($"No se encontró información del clima para la ciudad '{cityName}'")
    {
        CityName = cityName;
    }

    public CityNotFoundException(string cityName, Exception innerException)
        : base($"No se encontró información del clima para la ciudad '{cityName}'", innerException)
    {
        CityName = cityName;
    }
}
