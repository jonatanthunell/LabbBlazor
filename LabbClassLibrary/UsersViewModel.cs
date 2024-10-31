using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace LabbClassLibrary
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public IDataAccess DataAccess { get; init; }

        private UserCollectionFilterUtilities _userFilter;
        public UserCollectionFilterUtilities UserFilter
        {
            get { return _userFilter; }
            set
            {
                _userFilter = value;
                OnPropertyChanged(nameof(_userFilter));
            }
        }
        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        private List<User> _filteredUsers;
        public List<User> FilteredUsers
        {
            get { return _filteredUsers; }
            set
            {
                _filteredUsers = value;
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }
        public User UserWithShownTodos { get; set; }

        private string? _userDataErrorMessage;
        public string? UserDataErrorMessage 
        { 
            get => (_userDataErrorMessage == null) ? null : $"Could not load user data ({_userDataErrorMessage})"; 
            set => _userDataErrorMessage = value; 
        }
        public string? UserIndexOutOfRangeMessage { get; set; }
        public bool ShowToDos { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public UsersViewModel(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            _userFilter = new UserCollectionFilterUtilities();
            _users = new List<User>();
            _filteredUsers = new List<User>();
            UserWithShownTodos = new User();
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async Task SetUserDataAsync()
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
        public void ShowHideCurrentUsersToDos(User user)
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
        private void Sort() => FilteredUsers = FilteredUsers.Sort(UserFilter.SortOption);
    }
}
