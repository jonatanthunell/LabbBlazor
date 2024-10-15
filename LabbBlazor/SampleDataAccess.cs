namespace LabbBlazor
{
    public class SampleDataAccess : IDataAccess
    {
        public List<User> GetUsers()
        {
            SampleUserData userData = new SampleUserData();
            return userData.Users;
        }
        public List<ToDo> GetToDos()
        {
            SampleToDoData todoData = new SampleToDoData();
            return todoData.ToDos;
        }
    }
}
