namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public sealed record PokemonByNameResource(string Pokemon, object Species, object Type, int Id);
