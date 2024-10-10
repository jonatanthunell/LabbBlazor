namespace LabbBlazor
{
    public static class UserCollectionExtensions
    {
        public static List<User> OrderUsersByName(this List<User> users)
        {
            return users.OrderBy(x => x.Name).ToList();
        }
        public static List<User> OrderUsersById(this List<User> users)
        {
            return users.OrderBy(x => x.ID).ToList();
        }
        public static List<User> FilterUsersByName(this List<User> users, string searchTerm)
        {
            return users.Where(x => x.Name!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        }
        public static List<User> FilterUsersByCity(this List<User> users, string searchTerm)
        {
            return users.Where(x => x.Address.City!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        }
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

