namespace Domain.Entity;

public class Clima
{
    public string Pokemon { get; private set; }
    public int Id { get; private set; }
    

    public Pokedex(string pokemon, int id)
    {
        ArgumentException.ThrowIfNullOrEmpty(ciudad, nameof(pokemon));
        
        Pokemon = pokemon;
        Id = id;
    }

    public static Pokedex Create(string pokemon, int id, string type)
    {
        return new (pokemon, id, type);
    }
    

}