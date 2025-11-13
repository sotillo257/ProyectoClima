namespace Domain.Entity;

public class Pokedex
{
    public string Pokemon { get; private set; }
    public string Type { get; private set; } = string.Empty;


    public Pokedex(string pokemon, string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(pokemon, nameof(pokemon));

        Pokemon = pokemon;
        Type = type;
    }

    public static Pokedex Create(string pokemon, string type)
    {
        return new(pokemon, type);
    }
}
