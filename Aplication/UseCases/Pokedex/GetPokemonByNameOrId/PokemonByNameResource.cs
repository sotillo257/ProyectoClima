namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public sealed record PokemonByNameResource(string Pokemon, object species, object Type, int Id);
