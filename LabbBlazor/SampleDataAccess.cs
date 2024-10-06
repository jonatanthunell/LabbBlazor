namespace LabbBlazor
{
    public class SampleDataAccess
    {
        public List<User> GetUsers()
        {
            SampleUserData userData = new SampleUserData();
            return userData.Users;
        }
    }
}
