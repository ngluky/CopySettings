using CopySettings.Hellp;
using CopySettings.MVVM.View.Popup;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CopySettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static string path = /*System.AppDomain.CurrentDomain.BaseDirectory*/;

        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("./Ath/Ath.exe"))
            {
                DowAth.Visibility = Visibility.Visible;
                DowAthFun();
            }
            init();
        }

        void DowAthFun()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            Directory.CreateDirectory(@".\Ath\");
            Uri url = new Uri("https://raw.githubusercontent.com/ngluky/Ath/master/dist/Ath.exe");
            string pathfile = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Ath\Ath.exe";
            client.DownloadFileAsync(url , pathfile , null);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Ps.Text = $"{e.ProgressPercentage} %";
            Ps1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                DowAth.Visibility = Visibility.Hidden;
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DowAth.Visibility = Visibility.Hidden;
        }

        private async Task init()
        {

            async Task getCookie()
            {
                List<Account> data = null;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        data = await AthLogin.LoginCookie("./Ath/Cookie").ConfigureAwait(false);
                        this.Dispatcher.Invoke(() =>
                        {
                            var datacontext = this.DataContext as MainWindowViewModel;
                            foreach (var i in data)
                            {
                                datacontext.Users.Add(i);
                            }
                        });

                        return;
                    }
                    catch { }
                }
            }


            await getCookie();

        }

        private void Import_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

            if (button == null) return;
            Grid grid = (Grid)button.Parent;
            var chir = grid.Children[1];
            chir.IsEnabled = true;
        }

        private void Import_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

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
