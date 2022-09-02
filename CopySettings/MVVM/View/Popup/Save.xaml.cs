using CopySettings.Hellp;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace CopySettings.MVVM.View.Popup
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Save : UserControl , INotifyPropertyChanged
    {


        public ObservableCollection<Account> AccS { get; set; }
        private bool can = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Save()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += (s, e) =>
            {
                MainWindow Win = GetWindow(ExportPopup) as MainWindow;
                var datacontext = Win.DataContext as MainWindowViewModel;
                AccS = datacontext.Users;
                PropertyChanged(this, new PropertyChangedEventArgs("AccS"));
            };
        }

        private void close(object sender, RoutedEventArgs e)
        {

            MainWindow Win = GetWindow(ExportPopup) as MainWindow;

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

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "Settings";
            sfd.Filter = "json file (*.json)|*.json";

            MainWindow Win = GetWindow(ExportPopup) as MainWindow;
            var datacontext = Win.DataContext as MainWindowViewModel;
            var data = datacontext.data;
            Win.PopupUserControl.Content = null;

            if (data == null)
            {
                MessageBox.Show("Data is null");
                return;
            }

            Win.Popup.Visibility = Visibility.Hidden;

            string data_string = JsonConvert.SerializeObject(data);
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, data_string);
                MessageBox.Show("sava Complex");
                
            }

        }

        private async void ListAcc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var gird = sender as Grid;

            var user = gird.DataContext as Account;

            MainWindow Win = GetWindow(ExportPopup) as MainWindow;
            var datacontext = Win.DataContext as MainWindowViewModel;
            var data = datacontext.data;
            Win.Popup.Visibility = Visibility.Hidden;
            Win.PopupUserControl.Content = null;

            if (data == null)
            {
                MessageBox.Show("Data is null");
                return;
            }

            await ApiValorantCline.putUserSettings(user , data).ConfigureAwait(false);

            MessageBox.Show("save Complex");
        }
    }
}
