using CopySettings.Hellp;
using CopySettings.MVVM.View.Popup;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CopySettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
            
        }


        private async Task init()
        {
            List<Account> data = null;
            for (int i = 0; i <4; i++) 
            {
                try
                {
                    data = await AthLogin.LoginCookie("./Ath/Cookie").ConfigureAwait(false);
                    break;
                }
                catch { }
            }
            this.Dispatcher.Invoke(() =>
            {
                var datacontext = this.DataContext as MainWindowViewModel;
                datacontext.Users = new();
                foreach (var i in data)
                {
                    datacontext.Users.Add(i);
                }

            });
        }

        private void Import_MouseEnter(object sender, MouseEventArgs e)
        {
            CheckBox? button = sender as CheckBox;
            
            if (button == null) return;
            Grid grid = (Grid)button.Parent;
            var chir = grid.Children[1];
            if (button.IsChecked == true)
            {
                chir.IsEnabled = false; return;
            }
            chir.IsEnabled = true;
        }

        private void Import_MouseLeave(object sender, MouseEventArgs e)
        {
            CheckBox? button = sender as CheckBox;

            if (button == null) return;
            Grid grid = (Grid)button.Parent;
            var chir = grid.Children[1];
            chir.IsEnabled = false;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border? button = sender as Border;

            if (button == null) return;
            Grid grid = (Grid)button.Parent;
            var chir = grid.Children[1];
            chir.IsEnabled = true;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? button = sender as Border;

            if (button == null) return;
            Grid grid = (Grid)button.Parent;
            var chir = grid.Children[1];
            chir.IsEnabled = false;
        }

        private void ClickImport(object sender, RoutedEventArgs e)
        {
            Import impotPopup = new Import();
            PopupUserControl.Content = impotPopup;
            Popup.Visibility = Visibility.Visible;
            
        }

        private void ClickExport(object sender, RoutedEventArgs e)
        {
            Save save = new();
            PopupUserControl.Content = save;
            Popup.Visibility = Visibility.Visible;
        }

        private void ClickSetting(object sender, RoutedEventArgs e)
        {
            Setting setting = new();
            PopupUserControl.Content = setting;
            Popup.Visibility = Visibility.Visible;

        }



        private void Login(object sender, RoutedEventArgs e)
        {
            Acc.IsChecked = false;
            Login login = new();
            PopupUserControl.Content = login;
            Popup.Visibility = Visibility.Visible;

        }
    }
}
