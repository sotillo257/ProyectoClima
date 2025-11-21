namespace Aplication.UseCases.Pokedex.GetLocationsPaginated;

public sealed record GetLocationPaginatdRequest(int PageNumber, int PageSize, string SortOrder);
