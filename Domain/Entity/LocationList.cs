namespace Domain.Entity
{
    public class LocationList
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<string> Location{ get; set; } = new();
        public string SortBy { get; set; } = "location";
        public string SortOrder { get; set; } = "asc";

        public LocationList(List<string> location, int pageNumber, int pageSize, int totalCount)
        {
            Location = location;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
        public static LocationList Create(List<string> location, int pageNumber, int pageSize, int totalCount)
        {
            return new(location, pageNumber, pageSize, totalCount);
        }
    }
}
