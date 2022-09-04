using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {

            MainWindow Win = GetWindow(SettingPopup) as MainWindow;

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

        private void opendFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
        }
    }
}
