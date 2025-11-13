namespace Domain.Entity;

public class Pokedex
{
    public string Pokemon { get; private set; }
    public string Type { get; private set; } = string.Empty;
    public int Id { get; private set; }


    public Pokedex(string pokemon, string type, int id)
    {
        ArgumentException.ThrowIfNullOrEmpty(pokemon, nameof(pokemon));

        Pokemon = pokemon;
        Type = type;
        Id = id;
    }

    public static Pokedex Create(string pokemon, string type, int id)
    {
        return new(pokemon, type, id);
    }
}
