namespace LabbBlazor
{
    public enum UserProperty
    {
        ID, Name, Email, Street, City, ZipCode, Company, CatchPhrase
    }
    public class UsersPageUtilities
    {
        public UserProperty SortOption { get; set; }
        public UserProperty SearchOption { get; set; }
        public string SearchTerm { get; set; }

        public UsersPageUtilities()
        {
            SearchTerm = string.Empty;
            SearchOption = UserProperty.Name;
            SortOption = UserProperty.Name;
        }
    }
}
