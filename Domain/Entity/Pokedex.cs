namespace Domain.Entity;

public class Pokedex
{
    public string Pokemon { get; private set; }
    public object Species { get; private set; }
    public object Type { get; private set; } 
    public int Id { get; private set; }


    public Pokedex(string pokemon, object species, object type, int id)
    {
        ArgumentException.ThrowIfNullOrEmpty(pokemon, nameof(pokemon));

        Pokemon = pokemon;
        Species = species;
        Type = type;
        Id = id;
    }

    public static Pokedex Create(string pokemon, object species, object type, int id)
    {
        return new(pokemon, species, type, id);
    }
}
