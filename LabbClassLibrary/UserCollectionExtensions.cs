namespace LabbClassLibrary
{
    public static class UserCollectionExtensions
    {
        public static List<User> Sort(this List<User> users, UserProperty orderProperty) => orderProperty switch 
        { 
            UserProperty.Name => SortUsersByName(users),
            UserProperty.ID => SortUsersById(users),
            _ => SortUsersById(users)
        };
        public static List<User> Search(this List<User> users, UserProperty filterProperty, string searchTerm) => filterProperty switch
        {
            UserProperty.Name => SearchUsersByName(users, searchTerm),
            UserProperty.City => SearchUsersByCity(users, searchTerm),
            _ => SearchUsersByName(users, searchTerm)
        };
        private static List<User> SortUsersByName(List<User> users) => users.OrderBy(x => x.Name).ToList();
        private static List<User> SortUsersById(List<User> users) => users.OrderBy(x => x.ID).ToList();
        private static List<User> SearchUsersByName(List<User> users, string searchTerm) => users.Where(x => x.Name!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        private static List<User> SearchUsersByCity(List<User> users, string searchTerm) => users.Where(x => x.Address.City!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        public static List<User> SelectUsersByAmount(this List<User> users, int amount)
        {
            if (amount >= 0 && amount <= users.Count) 
            {
                return users.Take(amount).ToList();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}

