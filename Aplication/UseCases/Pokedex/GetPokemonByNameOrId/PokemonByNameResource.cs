namespace Aplication.UseCases.Pokedex.GetPokemonByNameOrId;

public sealed record PokemonByNameResource(string Pokemon, object Type, int Id);
