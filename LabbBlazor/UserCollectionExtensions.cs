namespace LabbBlazor
{
    public static class UserCollectionExtensions
    {
        public static List<User> Order(this List<User> users, UserProperty orderProperty) => orderProperty switch 
        { 
            UserProperty.Name => OrderUsersByName(users),
            UserProperty.ID => OrderUsersById(users),
            _ => OrderUsersById(users)
        };
        public static List<User> Search(this List<User> users, UserProperty filterProperty, string searchTerm) => filterProperty switch
        {
            UserProperty.Name => SearchUsersByName(users, searchTerm),
            UserProperty.City => SearchUsersByCity(users, searchTerm),
            _ => SearchUsersByName(users, searchTerm)
        };
        private static List<User> OrderUsersByName(List<User> users) => users.OrderBy(x => x.Name).ToList();
        private static List<User> OrderUsersById(List<User> users) => users.OrderBy(x => x.ID).ToList();
        private static List<User> SearchUsersByName(List<User> users, string searchTerm) => users.Where(x => x.Name!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        private static List<User> SearchUsersByCity(List<User> users, string searchTerm) => users.Where(x => x.Address.City!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        public static List<User> FilterUsersByAmount(this List<User> users, int amount)
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

