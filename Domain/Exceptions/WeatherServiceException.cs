namespace Domain.Exceptions;

public class WeatherServiceException : Exception
{
    public int? StatusCode { get; }

    public WeatherServiceException(string message) : base(message)
    {
    }

    public WeatherServiceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WeatherServiceException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public WeatherServiceException(string message, int statusCode, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
