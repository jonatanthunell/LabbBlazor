namespace LabbClassLibrary
{
    public class UserCollectionFilterUtilities
    {
        public UserProperty SortOption { get; set; }
        public UserProperty SearchOption { get; set; }
        public string SearchTerm { get; set; }
        public int NumberOfShownUsers { get; set; }
        public UserCollectionFilterUtilities()
        {
            SearchTerm = string.Empty;
            SearchOption = UserProperty.Name;
            SortOption = UserProperty.Name;
        }
    }
}
