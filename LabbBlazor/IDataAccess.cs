namespace LabbBlazor
{
    public interface IDataAccess
    {
        public List<User> GetUsers();
        public List<ToDo> GetToDos();
    }
}
