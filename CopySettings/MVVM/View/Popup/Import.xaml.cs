using CopySettings.Hellp;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CopySettings.MVVM.View.Popup
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : UserControl, INotifyPropertyChanged
    {
        
        public ObservableCollection<Account> AccS { get; set; }
        private bool can = true;

        public Import()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += (s, e) =>
            {
                MainWindow Win = GetWindow(ImportPopup) as MainWindow;
                var datacontext = Win.DataContext as MainWindowViewModel;
                AccS = datacontext.Users;
                PropertyChanged(this, new PropertyChangedEventArgs("AccS"));
            };

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void close(object sender, RoutedEventArgs e)
        {

            MainWindow Win = GetWindow(ImportPopup) as MainWindow;

            Win.Popup.Visibility = Visibility.Hidden;
            ;
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

        private void openFile(object sender, RoutedEventArgs e)
        {
            string dataString;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                dataString = File.ReadAllText(openFileDialog.FileName);
                var data = JsonConvert.DeserializeObject<Data>(dataString);
                MainWindow Win = GetWindow(ImportPopup) as MainWindow;
                MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                datacontext.data = data;
                Win.Popup.Visibility = Visibility.Hidden;
                Win.PopupUserControl.Content = null;

                var viewsetting = Win.ViewSetting.Content as SettingUserView;

                var datacontext_ = viewsetting.DataContext as SettingUserViewModel;
                datacontext_.SetData(data);

                MessageBox.Show("import Complex");

            }
        }


        private async void ListAcc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            var gird = sender as Grid;

            var user = gird.DataContext as Account;

            var data = await ApiValorantCline.FetchUserSettings(user).ConfigureAwait(false);

            this.Dispatcher.Invoke(() =>
            {
                MainWindow Win = GetWindow(ImportPopup) as MainWindow;
                MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                datacontext.data=data;
                Win.Popup.Visibility = Visibility.Hidden;
                Win.PopupUserControl.Content = null;

                var viewsetting = Win.ViewSetting.Content as SettingUserView;

                var datacontext_ = viewsetting.DataContext as SettingUserViewModel;
                datacontext_.SetData(data);

                MessageBox.Show("import Complex");
            });


        }
    }
}
