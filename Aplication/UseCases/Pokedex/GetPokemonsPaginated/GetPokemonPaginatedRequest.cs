namespace Aplication.UseCases.Pokedex.GetPokemonsPaginated;

public sealed record GetPokemonPaginatedRequest(int PageNumber, int PageSize);
