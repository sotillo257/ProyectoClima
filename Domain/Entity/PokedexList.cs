namespace Domain.Entity
{
    public class PokedexList
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<string> Name{ get; set; } = new();

        public PokedexList(List<string> name, int pageNumber, int pageSize, int totalCount)
        {
            Name = name;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
        public static PokedexList Create(List<string> name, int pageNumber, int pageSize, int totalCount)
        {
            return new(name, pageNumber, pageSize, totalCount);
        }
    }
}
