using CopySettings.Hellp;
using CopySettings.Obje.GuiObj;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;
using CopySettings.MVVM.ViewModel;

namespace CopySettings.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingUserView.xaml
    /// </summary>
    public partial class SettingUserView : UserControl
    {


        public SettingUserView()
        {
            InitializeComponent();
            //KeyDown += new KeyEventHandler(SettingUserView_KeyDown);
            MouseDown += new MouseButtonEventHandler(SettingUserView_MouseDown);
            var task = RenderGuiGENERAL(@"Gui\Gui.json");
            task.Wait();
            //this.Loaded += SettingUserView_Loaded;
        }

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
                StackPanel stackPanel = await Render.RenderGroup(this,i).ConfigureAwait(false);
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SetProfiles(object sender, RoutedEventArgs e)
        {
            SettingUserViewModel datacontext = this.DataContext as SettingUserViewModel;
            if (datacontext.data.actionMappings.ContainsKey("None"))
            {
                datacontext.KeyBind = datacontext.data.actionMappings["None"];
            }
        }
    }
}
