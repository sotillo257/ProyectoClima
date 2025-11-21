namespace Aplication.UseCases.Pokedex.GetLocationsPaginated;

public record LocationsPaginatedResource(int PageNumber, int PageSize, int TotalCount, List<string> Location, string SortBy, string SortOrder);
