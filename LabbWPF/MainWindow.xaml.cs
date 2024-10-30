using System.Windows;

namespace LabbWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FrameworkElement _newUserView;
        private FrameworkElement _usersView;
        public MainWindow()
        {
            InitializeComponent();

            _newUserView = new NewUserView();
            _usersView = new UsersView();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            content.Content = _newUserView;
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            content.Content = _usersView;
        }
    }
    
}