namespace Domain.Entity
{
    public class Pagination
    {
        private const int MaxPageSize = 100;
        private int pageSize = 10;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
