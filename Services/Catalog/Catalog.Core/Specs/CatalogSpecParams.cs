namespace Catalog.Core.Specs
{
    public class CatalogSpecParams
    {
        private int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageIndex  { get; set; } = 1;
        public int PageSize
        { 
          get  =>    _pageSize;
          set  =>    _pageSize = value < MaxPageSize ? value : MaxPageSize;
        }


        public string?  Search { get; set; }
        public string? OrderBy { get; set; }
        public string? BrandId { get; set; }
        public string? TypeID { get; set; }
    }
}
