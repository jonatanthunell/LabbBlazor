using System.Net.Sockets;
using System.Text.Json;

namespace LabbBlazor
{
    public class UsersViewModel
    {
        public IDataAccess DataAccess { get; init; }
        public UserCollectionFilterUtilities UserFilter { get; private set; }
        public List<User> Users { get; private set; }
        public List<User> FilteredUsers { get; set; }
        public User UserWithShownTodos { get; set; }

        private string? _userDataErrorMessage;
        public string? UserDataErrorMessage 
        { 
            get => (_userDataErrorMessage == null) ? null : $"Could not load user data ({_userDataErrorMessage})"; 
            set => _userDataErrorMessage = value; 
        }
        public string? UserIndexOutOfRangeMessage { get; set; }
        public bool ShowToDos { get; set; }
        public UsersViewModel(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            UserFilter = new UserCollectionFilterUtilities();
            Users = new List<User>();
            FilteredUsers = new List<User>();
            UserWithShownTodos = new User();
        }
        public async Task SetUserData()
        {
            try
            {
                var users = await DataAccess.GetUsersAsync();
                Users = users.ToList();
                UserDataErrorMessage = null;
            }
            catch (DirectoryNotFoundException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (FileNotFoundException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (IOException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (JsonException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (NotSupportedException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (SocketException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (HttpRequestException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                UserDataErrorMessage = ex.Message;
            }
        }
        public void ShowHideToDos(User user)
        {
            if (user == UserWithShownTodos)
            {
                ShowToDos = (ShowToDos) ? false : true;
            }
            else
            {
                ShowToDos = true;
            }
            UserWithShownTodos = user;
        }
        public void ShowAll()
        {
            UserFilter.NumberOfShownUsers = (Users != null) ? Users.Count : 0;
            Filter();
        }
        public void ShowLess()
        {
            UserFilter.NumberOfShownUsers = 5;
            Filter();
        }
        public void Filter()
        {
            Search();
            Sort();
            if (UserFilter.NumberOfShownUsers < FilteredUsers.Count)
            {
                ShowNumberOfUsers();
            }
        }
        private void ShowNumberOfUsers()
        {
            try
            {
                FilteredUsers = FilteredUsers.SelectUsersByAmount(UserFilter.NumberOfShownUsers);
                UserIndexOutOfRangeMessage = null;
            }
            catch (ArgumentOutOfRangeException e)
            {
                UserIndexOutOfRangeMessage = e.Message;
            }
        }
        private void Search() => FilteredUsers = Users.Search(UserFilter.SearchOption, UserFilter.SearchTerm);
        private void Sort() => FilteredUsers = FilteredUsers.Order(UserFilter.SortOption);
    }
}
