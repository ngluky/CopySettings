using CopySettings.Hellp;
using CopySettings.MVVM.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CopySettings.MVVM.View.Popup
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, INotifyPropertyChanged
    {
        public Login()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void close(object sender, RoutedEventArgs e)
        {

            MainWindow Win = GetWindow(LoginPopup) as MainWindow;

            Win.Popup.Visibility = Visibility.Hidden;
            Win.PopupUserControl.Content = null;

        }

        private FrameworkElement GetWindow(UserControl e)
        {
            FrameworkElement par = e;
            while (par.Parent != null)
            {
                par = par.Parent as FrameworkElement;
            }

            return par;
        }

        private async void LogIn(object sender, RoutedEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            var user = await AthLogin.LoginUserPass(User.Text, PasswordBox.Password).ConfigureAwait(false);
            this.Dispatcher.Invoke(() =>
            {
                MainWindow Win = GetWindow(LoginPopup) as MainWindow;
                MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                datacontext.Users.Add(user);
                Win.Popup.Visibility = Visibility.Hidden;
                Win.PopupUserControl.Content = null;
                MessageBox.Show("login Complex");


            });

        }
    }
}
