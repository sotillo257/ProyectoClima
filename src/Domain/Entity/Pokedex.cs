using System;

namespace Domain.Entity;

public class Pokedex
{
    public string Pokemon { get; private set; }
    public string Species { get; private set; }
    public string Type { get; private set; } 
    public int Id { get; private set; }


    private Pokedex(string pokemon, string species, string type, int id)
    {
        ArgumentException.ThrowIfNullOrEmpty(pokemon, nameof(pokemon));

        Pokemon = pokemon;
        Species = species;
        Type = type;
        Id = id;
    }

    public static Pokedex Create(string pokemon, string species, string type, int id)
    {
        return new(pokemon, species, type, id);
    }
}
