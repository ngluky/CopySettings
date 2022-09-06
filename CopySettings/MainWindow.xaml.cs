﻿using CopySettings.Hellp;
using CopySettings.MVVM.View.Popup;
using CopySettings.MVVM.ViewModel;
using CopySettings.Obje;
using CopySettings.Obje.GuiObj;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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
                DowAthExe();
            }
            init();
        }


        void DowAthExe()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            Directory.CreateDirectory(@".\Ath\");
            Uri url = new Uri("https://raw.githubusercontent.com/ngluky/Ath/master/dist/Ath.exe");
            string pathfile = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Ath\Ath.exe";
            client.DownloadFileAsync(url, pathfile, null);
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
            var datacontext = this.DataContext as MainWindowViewModel;

            async Task LoginWithCookie()
            {
                List<Account> data = null;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        data = await AthLogin.LoginCookie("./Ath/Cookie").ConfigureAwait(false);
                        if (data == null) return;
                        this.Dispatcher.Invoke(() =>
                        {
                            foreach (var i in data)
                            {
                                var item = datacontext.Users.FirstOrDefault(x => x.DisplayName == i.DisplayName);
                                if (item != null) return;
                                datacontext.Users.Add(i);
                            }
                        });

                        return;
                    }
                    catch
                    {
                        Constants.Log.Error($"try Cookie {i}");
                    }
                }
            }

            async Task GetSettingDefault()
            {
                RestClient client = new RestClient("https://raw.githubusercontent.com/ngluky/Valorant-Setting-Default/main/setting.json");
                RestRequest restRequest = new RestRequest();
                RestResponse response = await client.ExecuteGetAsync(restRequest).ConfigureAwait(false);
                if (response.IsSuccessful)
                {
                    Constants.SettingDefault_string = response.Content;
                    var data = JsonConvert.DeserializeObject<Data>(response.Content);
                    datacontext.SetData(data);
                    Constants.SettingDefault = data;
                }
            }

            Task.WhenAll(GetSettingDefault(), RenderGuiGENERAL(@"Gui\Gui.json"), LoginWithCookie());

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

        public void SetGuiFile(string Path)
        {
            RenderGuiGENERAL(Path);
        }

        #region show popup
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

        #endregion

        #region close
        private void close_Popup(object sender, MouseButtonEventArgs e)
        {
            PopupUserControl.Content = null;
            Popup.Visibility = Visibility.Hidden;
            var data = DataContext as MainWindowViewModel;
            data.AccIsCheck = false;
        }

        #endregion

        private void SettingUserView_KeyDown(object sender, KeyEventArgs e)
        {
            GetTextBoxFocused(e.Key.ToString());
        }

        private void SettingUserView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetTextBoxFocused(e.ChangedButton.ToString());
        }

        public async Task RenderGuiGENERAL(string path)
        {
            string alltext = File.ReadAllText(path);
            Gui data = JsonConvert.DeserializeObject<Gui>(alltext);
            //MessageBox.Show("ok");
            if (data.general == null)
            {
                MessageBox.Show("Loading Gui Fail");
                return;
            }
            GENERAL.Children.Clear();
            foreach (var i in data.general)
            {
                StackPanel stackPanel = await Render.RenderGroup(this, i).ConfigureAwait(false);
                GENERAL.Children.Add(stackPanel);
            }

            foreach (var i in data.control)
            {

            }

        }

        private void GetTextBoxFocused(string text)
        {

            foreach (var i in CONTROL.Children)
            {
                StackPanel stackPanel = i as StackPanel;
                foreach (var j in stackPanel.Children)
                {
                    if (j.GetType() == typeof(Border))
                    {
                        var textbox = GetTexts(j as Border);
                        if (textbox == null) continue;
                        textbox.Text = text;
                    }
                }
            }

        }

        private TextBox GetTexts(Border b)
        {
            Grid grid = b.Child as Grid;
            Grid grid1 = grid.Children[1] as Grid;
            foreach (var i in grid1.Children)
            {
                TextBox textBox = i as TextBox;
                if (textBox.IsFocused)
                {
                    return textBox;
                }
            }

            return null;
        }


        private void SetProfiles(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel datacontext = this.DataContext as MainWindowViewModel;
            if (datacontext.data.actionMappings.ContainsKey("None"))
            {
                //datacontext.KeyBind = datacontext.data.actionMappings["None"];
            }
        }

    }
}
