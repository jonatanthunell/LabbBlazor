using LabbClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace LabbWPF
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private UsersViewModel _viewModel;
        private ToDosViewModel? _toDosViewModel;
        public UsersView()
        {
            InitializeComponent();
            _viewModel = new UsersViewModel(new ApiDataAccess());            
            DataContext = _viewModel;
        }
        private async void OnLoaded_Event(object sender, RoutedEventArgs e)
        {
            await _viewModel.SetUserDataAsync();
            _viewModel.UserFilter.NumberOfShownUsers = _viewModel.Users.Count;
            _viewModel.Filter();
        }
        private void SearchOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = searchOption.SelectedItem as ComboBoxItem;

            if (selectedItem != null && _viewModel != null)
            {
                switch (selectedItem.Content)
                {
                    case "By Name":
                        _viewModel.UserFilter.SearchOption = UserProperty.Name;
                        break;
                    case "By City":
                        _viewModel.UserFilter.SearchOption = UserProperty.City;
                        break;
                    case null:
                        _viewModel.UserFilter.SearchOption = UserProperty.Name;
                        break;
                }
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Filter();
        }
        private async void Showtodos_Click(object sender, RoutedEventArgs e)
        {
            if (users.SelectedItem != null)
            {
                _viewModel.UserWithShownTodos = users.SelectedItem as User ?? new User();
            }

            _toDosViewModel = new ToDosViewModel(_viewModel.DataAccess, _viewModel.UserWithShownTodos);
            await _toDosViewModel.SetToDoDataAsync();
            _toDosViewModel.SetCurrentUserTodos();
            _toDosViewModel.Filter();

            todos.DataContext = _toDosViewModel;
        }
    }
}
