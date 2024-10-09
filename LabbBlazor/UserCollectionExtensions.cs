namespace LabbBlazor
{
    public static class UserCollectionExtensions
    {
        public static List<User> SortByName(this List<User> users)
        {
            return users.OrderBy(x => x.Name).ToList();
        }
        public static List<User> SortById(this List<User> users)
        {
            return users.OrderBy(x => x.ID).ToList();
        }
        public static List<User> SearchByName(this List<User> users, string searchTerm)
        {
            return users.Where(x => x.Name!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        }
        public static List<User> SearchByCity(this List<User> users, string searchTerm)
        {
            return users.Where(x => x.Address.City!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        }
        public static List<User> FilterByAmount(this List<User> users, int amount)
        {
            return users.Take(amount).ToList();
        }
        
    }
}

