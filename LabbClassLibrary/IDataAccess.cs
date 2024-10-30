namespace LabbClassLibrary
{
    public interface IDataAccess
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<IEnumerable<ToDo>> GetToDosAsync();
    }
}
