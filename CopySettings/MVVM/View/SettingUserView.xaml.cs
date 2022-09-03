using CopySettings.Hellp;
using CopySettings.Obje.GuiObj;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            var task = RenderGuiGENERAL();
            task.Wait();
        }

        private async Task RenderGuiGENERAL()
        {
            string alltext = File.ReadAllText(@"C:\Users\Administrator\Downloads\Gui.json");
            var data = JsonConvert.DeserializeObject<Group[]>(alltext);
            //MessageBox.Show("ok");

            foreach (var i in data)
            {
                StackPanel stackPanel = await Render.RenderGroup(this,i).ConfigureAwait(false);
                GENERAL.Children.Add(stackPanel);
            }

        }


        // Convert value textbox to sliderX
        
    }
}
