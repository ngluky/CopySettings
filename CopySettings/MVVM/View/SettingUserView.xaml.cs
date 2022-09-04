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
            this.KeyDown += SettingUserView_KeyDown;
            this.MouseDown += SettingUserView_MouseDown;
            var task = RenderGuiGENERAL();
            task.Wait();
        }

        private void SettingUserView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //GetTextBoxFocused(e.)
        }

        private void SettingUserView_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            GetTextBoxFocused(e.Key.ToString());
        }





        private async Task RenderGuiGENERAL()
        {
            string alltext = File.ReadAllText(@"Gui\Gui.json");
            Gui data = JsonConvert.DeserializeObject<Gui>(alltext);
            //MessageBox.Show("ok");

            foreach (var i in data.general)
            {
                StackPanel stackPanel = await Render.RenderGroup(this,i).ConfigureAwait(false);
                GENERAL.Children.Add(stackPanel);
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
    }
}
