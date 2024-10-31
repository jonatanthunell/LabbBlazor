namespace LabbClassLibrary
{
    public class NewUserViewModel : ViewModel
    {
        public User ValidatedUser { get; set; }
        public NewUserViewModel()
        {
            ValidatedUser = new User();
        }
    }
}
