using LabbClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace LabbWPF
{
    /// <summary>
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class NewUserView : UserControl
    {
        private NewUserViewModel _viewModel;
        public NewUserView()
        {
            InitializeComponent();
            _viewModel = new NewUserViewModel();
            DataContext = _viewModel;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            submitedUser.Content = new SubmitedUserView();
        }
    }
}
