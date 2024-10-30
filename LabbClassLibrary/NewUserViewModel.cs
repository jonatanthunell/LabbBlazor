namespace LabbClassLibrary
{
    public class NewUserViewModel
    {
        public User ValidatedUser { get; set; }
        public NewUserViewModel()
        {
            ValidatedUser = new User();
        }
    }
}
