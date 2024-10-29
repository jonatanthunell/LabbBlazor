using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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