using System.Text.Json.Serialization;

namespace ClassLibrary1.Recursos;

public class ClimaDTO
{
    [JsonPropertyName("coord")]
    public Coord Coord { get; init; } = default!;

    [JsonPropertyName("weather")]
    public List<WeatherItem> Weather { get; init; } = new();

    // "base" es palabra clave; se mapea con atributo
    [JsonPropertyName("base")]
    public string Base { get; init; } = string.Empty;

    [JsonPropertyName("main")]
    public MainInfo Main { get; init; } = default!;

    [JsonPropertyName("visibility")]
    public int Visibility { get; init; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; init; } = default!;

    [JsonPropertyName("clouds")]
    public Clouds Clouds { get; init; } = default!;

    // Epoch segundos: usa long por seguridad
    [JsonPropertyName("dt")]
    public long Dt { get; init; }

    [JsonPropertyName("sys")]
    public Sys Sys { get; init; } = default!;

    [JsonPropertyName("timezone")]
    public int Timezone { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("cod")]
    public int Cod { get; init; }
}

public sealed class Coord
{
    [JsonPropertyName("lon")]
    public double Lon { get; init; }

    [JsonPropertyName("lat")]
    public double Lat { get; init; }
}

public sealed class WeatherItem
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("main")]
    public string Main { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = string.Empty;
}

public sealed class MainInfo
{
    [JsonPropertyName("temp")]
    public double Temp { get; init; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; init; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; init; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; init; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; init; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; init; }

    [JsonPropertyName("sea_level")]
    public int? SeaLevel { get; init; }

    [JsonPropertyName("grnd_level")]
    public int? GroundLevel { get; init; }
}

public sealed class Wind
{
    [JsonPropertyName("speed")]
    public double Speed { get; init; }

    [JsonPropertyName("deg")]
    public int Deg { get; init; }
}

public sealed class Clouds
{
    [JsonPropertyName("all")]
    public int All { get; init; }
}

public sealed class Sys
{
    [JsonPropertyName("type")]
    public int? Type { get; init; }

    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("country")]
    public string Country { get; init; } = string.Empty;

    [JsonPropertyName("sunrise")]
    public long Sunrise { get; init; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; init; }
}