namespace LabbBlazor
{
    public enum SearchOption
    {
        Name,
        City
    }
    public enum SortOption
    {
        Name,
        ID
    }
    public class UsersPageUtilities
    {
        public SortOption SortOption { get; set; }
        public SearchOption SearchOption { get; set; }
        public string SearchTerm { get; set; }

        public UsersPageUtilities()
        {
            SearchTerm = string.Empty;
            SearchOption = SearchOption.Name;
            SortOption = SortOption.Name;
        }
    }
}
