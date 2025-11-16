namespace ClassLibrary1.Configuration;

public class OpenWeatherMapOptions
{
    public const string SectionName = "OpenWeatherMap";

    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "https://api.openweathermap.org/";
    public int TimeoutSeconds { get; set; } = 30;
}
