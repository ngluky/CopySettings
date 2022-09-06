using CopySettings.Hellp;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                data = Utils.FillData(data);
                MainWindow Win = GetWindow(ImportPopup) as MainWindow;
                MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                datacontext.SetData(data);

                Win.Popup.Visibility = Visibility.Hidden;
                Win.PopupUserControl.Content = null;

                Constants.Log.Information("imput Complex");
                //MessageBox.Show("import Complex");

            }
        }

        //get data user
        private async void ListAcc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            var gird = sender as Grid;
            var user = gird.DataContext as Account; // get account

            var data = await ApiValorantCline.FetchUserSettings(user).ConfigureAwait(false);
            data = Utils.FillData(data);

            this.Dispatcher.Invoke(() =>
            {
                MainWindow Win = GetWindow(ImportPopup) as MainWindow;
                MainWindowViewModel datacontext = Win.DataContext as MainWindowViewModel;
                datacontext.SetData(data);
                Win.Popup.Visibility = Visibility.Hidden;
                Win.PopupUserControl.Content = null;

                Constants.Log.Information("imput Complex");

            });
        }

        private async void DataFill()
        {

        }
    }
}
