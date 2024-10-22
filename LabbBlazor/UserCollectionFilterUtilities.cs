namespace LabbBlazor
{
    public enum UserProperty
    {
        ID, Name, Email, Street, City, ZipCode, Company, CatchPhrase
    }
    public class UserCollectionFilterUtilities
    {
        public UserProperty SortOption { get; set; }
        public UserProperty SearchOption { get; set; }
        public string SearchTerm { get; set; }

        public UserCollectionFilterUtilities()
        {
            SearchTerm = string.Empty;
            SearchOption = UserProperty.Name;
            SortOption = UserProperty.Name;
        }
    }
}
