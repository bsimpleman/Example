

namespace BlazorApp1.DTOs.DTOs
{
    public class PagedList//<T> : List<T>
    {
        //public List<T> Data { get; set; } = new List<T>();
        public int pgNum { get; set; }
        public string? searchText { get; set; }
        public string? searchCategory { get; set; }
        public string? RecCnt { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
    }
}
