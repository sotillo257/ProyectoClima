namespace Domain.Entity
{
    public sealed record Pagination(int PageNumber, int PageSize, string SortBy, string SortOrder);
}
