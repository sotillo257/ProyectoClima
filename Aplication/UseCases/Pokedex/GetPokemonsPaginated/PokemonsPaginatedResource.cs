namespace Aplication.UseCases.Pokedex.GetPokemonsPaginated;

public record PokemonsPaginatedResource(int PageNumber, int PageSize, int TotalCount, List<string> Name);
