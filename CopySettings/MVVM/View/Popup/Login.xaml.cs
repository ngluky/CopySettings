using CopySettings.Hellp;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using System.ComponentModel;
using System.Linq;
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
            Account? user = await AthLogin.LoginUserPass(User.Text, PasswordBox.Password , (bool)remember.IsChecked).ConfigureAwait(false);

            if (user != null)
            {
                this.Dispatcher.Invoke(() =>
                {
                    MainWindow Win = GetWindow(LoginPopup) as MainWindow;
                    MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                    var item = datacontext.Users.FirstOrDefault(x => x.DisplayName == user.DisplayName);
                    if (item != null)
                    {
                        Win.Popup.Visibility = Visibility.Hidden;
                        Win.PopupUserControl.Content = null;
                        MessageBox.Show("Account have exit");
                        err.Visibility = Visibility.Hidden;
                        err.Height = 0;
                        return;
                    };
                    datacontext.Users.Add(user);
                    Win.Popup.Visibility = Visibility.Hidden;
                    Win.PopupUserControl.Content = null;
                    MessageBox.Show("login Complex");
                    err.Visibility = Visibility.Hidden;
                    err.Height = 0;
                    });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    err.Visibility = Visibility.Visible;
                    err.Text = "Login fail";
                    err.Height = 20;
                    Loading.Visibility = Visibility.Hidden;
                });
            }

        }
    }
}
