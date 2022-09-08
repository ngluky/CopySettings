using CopySettings.MVVM.ViewModel;
using CopySettings.Obje.GuiObj;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CopySettings.Hellp
{
    public static class Render
    {
        private static async Task<Border> IntSettingList(Object sender, Item i)
        {
            var settinview = sender as MainWindow;
            Border border = new Border();
            border.Margin = new Thickness(30, 0, 0, 0);
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.Height = 43;
            Binding binding_datacontext = new Binding("intSettings");
            border.SetBinding(Border.DataContextProperty, binding_datacontext);

            Grid grid = new Grid();
            #region child gir
            TextBlock textblock = new TextBlock();
            #region textblock parameter
            textblock.Text = i.Name;
            textblock.Foreground = new SolidColorBrush(Colors.White);
            textblock.FontSize = 15;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(textblock);
            #endregion

            ComboBox comboBox = new ComboBox();
            Binding bindingItemIndex = new Binding(i.path);
            //bindingItemIndex.Converter = new DefaultValue();
            //bindingItemIndex.ConverterParameter = 2;

            comboBox.Style = (Style)settinview.Resources["Combox"];
            string[] itmesor = i.TextSwich.Split("|");
            comboBox.ItemsSource = itmesor;
            comboBox.SelectedItem = itmesor[2];
            comboBox.SetBinding(ComboBox.SelectedIndexProperty, bindingItemIndex);
            comboBox.Height = 30;
            comboBox.VerticalAlignment = VerticalAlignment.Center;
            comboBox.HorizontalAlignment = HorizontalAlignment.Right;
            comboBox.Foreground = new SolidColorBrush(Colors.White);
            comboBox.Width = 250;
            comboBox.Margin = new Thickness(0, 0, 15, 0);
            grid.Children.Add(comboBox);



            Border border1 = new Border();
            #region border1 parameter
            border1.Height = 1;
            border1.Background = new SolidColorBrush(Colors.DarkGray);
            border1.VerticalAlignment = VerticalAlignment.Bottom;
            border1.Margin = new Thickness(10, 0, 20, 0);
            grid.Children.Add(border1);
            #endregion

            #endregion

            border.Child = grid;
            return border;
        }

        private static async Task<Border> BoolSetting(Object sender, Item i)
        {
            var settinview = sender as MainWindow;
            Border border = new Border();
            border.Margin = new Thickness(30, 0, 0, 0);
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.Height = 43;
            Binding binding_datacontext = new Binding("boolSettings");
            border.SetBinding(Border.DataContextProperty, binding_datacontext);

            Grid grid = new Grid();
            #region child gir
            TextBlock textblock = new TextBlock();
            #region textblock parameter
            textblock.Text = i.Name;
            textblock.Foreground = new SolidColorBrush(Colors.White);
            textblock.FontSize = 15;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(textblock);
            #endregion

            CheckBox checkBox = new CheckBox();
            #region checkbox parameter
            checkBox.Background = Brushes.Transparent;
            checkBox.Style = (Style)settinview.FindResource("switchStype");
            checkBox.Margin = new Thickness(0, 5, 15, 5);
            checkBox.Width = 250;
            checkBox.HorizontalAlignment = HorizontalAlignment.Right;
            checkBox.Content = i.TextSwich;
            Binding binding_Ischeck = new Binding(i.path);
            checkBox.SetBinding(CheckBox.IsCheckedProperty, binding_Ischeck);
            //checkBox.Name = i.Name.Replace(' ', '_').Replace(":", String.Empty);
            grid.Children.Add(checkBox);
            #endregion


            Border border1 = new Border();
            #region border1 parameter
            border1.Height = 1;
            border1.Background = new SolidColorBrush(Colors.DarkGray);
            border1.VerticalAlignment = VerticalAlignment.Bottom;
            border1.Margin = new Thickness(10, 0, 20, 0);
            grid.Children.Add(border1);
            #endregion

            #endregion

            border.Child = grid;



            return border;

        }

        private static async Task<Border> FloatSetting(Object sender, Item i)
        {
            var settinview = sender as MainWindow;
            Border border = new Border();
            border.Margin = new Thickness(30, 0, 0, 0);
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.Height = 43;
            Binding binding_datacontext = new Binding("floatSettings");
            border.SetBinding(Border.DataContextProperty, binding_datacontext);

            Grid grid = new Grid();

            TextBlock textBlock = new TextBlock();
            #region textBlock parameter

            textBlock.Text = i.Name;
            textBlock.Foreground = new SolidColorBrush(Colors.White);
            textBlock.FontSize = 15;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            grid.Children.Add(textBlock);
            #endregion


            TextBox textBox = new TextBox();
            #region textBox parameter
            textBox.Foreground = new SolidColorBrush(Colors.White);
            textBox.FontSize = 15;
            textBox.TextChanged += TexBlockChange;
            textBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffffff"); ;
            textBox.Background = new SolidColorBrush(Colors.Transparent);
            textBox.CaretBrush = new SolidColorBrush(Colors.Purple);
            textBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            textBox.BorderThickness = new Thickness(0, 0, 0, 1);
            textBox.MinWidth = 5;
            Binding binding_text = new Binding(i.path);
            binding_text.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            textBox.SetBinding(TextBox.TextProperty, binding_text);
            //textBox.Name = i.Name.Replace(' ', '_').Replace(":", String.Empty);
            textBox.Style = new Style();
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Children.Add(textBox);
            #endregion

            Slider slider = new Slider();
            slider.Minimum = i.Minimum;
            slider.Maximum = i.Maximum;
            slider.ValueChanged += Slider_ValueChanged;
            slider.Style = (Style)settinview.Resources["AppSliderStyle"];
            slider.HorizontalAlignment = HorizontalAlignment.Right;
            slider.Width = 250;
            slider.Value = 0;
            slider.Margin = new Thickness(0, 0, 15, 0);
            grid.Children.Add(slider);

            Border border1 = new Border();
            #region border1 parameter
            border1.Height = 1;
            border1.Background = new SolidColorBrush(Colors.DarkGray);
            border1.VerticalAlignment = VerticalAlignment.Bottom;
            border1.Margin = new Thickness(10, 0, 20, 0);
            grid.Children.Add(border1);
            #endregion


            border.Child = grid;

            return border;

        }

        private static async Task<Border> KeyBindSetting(Object sender, Item i)
        {

            MainWindow settinview = sender as MainWindow;
            MainWindowViewModel datacontext = settinview.DataContext as MainWindowViewModel;

            Border border = new Border();
            border.Margin = new Thickness(30, 0, 0, 0);
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.Height = 45;
            Binding border_biding = new Binding(i.path);

            border.SetBinding(Border.DataContextProperty, border_biding);
            //border.MouseDown += Border_MouseDown;

            Grid grid = new Grid();

            TextBlock textBlock = new TextBlock();
            textBlock.Text = i.Name;
            textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.FontSize = 17;
            textBlock.Width = 250;

            grid.Children.Add(textBlock);

            Grid grid1 = new Grid();
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.HorizontalAlignment = HorizontalAlignment.Right;
            grid1.Margin = new Thickness(0, 0, 15, 0);
            grid1.Height = 35;
            grid1.VerticalAlignment = VerticalAlignment.Center;
            grid1.Width = 250;


            TextBox textBlock1 = new TextBox();
            string path1 = "KeyIndex1";

            Binding binding1 = new Binding(path1);
            textBlock1.SetBinding(TextBox.TextProperty, binding1);
            textBlock1.Margin = new Thickness(3, 3, 3, 3);
            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock1.Padding = new Thickness(10);
            textBlock1.Style = (Style)settinview.Resources["keybind"];
            textBlock1.MaxLength = 1;
            //textBlock1.SetValue(Grid.ColumnProperty, 0);

            Grid.SetColumn(textBlock1, 0);
            grid1.Children.Add(textBlock1);

            TextBox textBlock2 = new TextBox();
            string path2 = "KeyIndex2";
            Binding binding2 = new Binding(path2);
            textBlock2.SetBinding(TextBox.TextProperty, binding2);
            textBlock2.Margin = new Thickness(3, 3, 3, 3);
            textBlock2.TextAlignment = TextAlignment.Center;
            textBlock2.Padding = new Thickness(10);
            textBlock2.Style = (Style)settinview.Resources["keybind"];
            textBlock2.MaxLength = 1;
            //textBlock2.SetValue(Grid.ColumnProperty, 1);

            Grid.SetColumn(textBlock2, 1);
            grid1.Children.Add(textBlock2);

            grid.Children.Add(grid1);

            Border border1 = new Border();

            border1.Height = 1;
            border1.Background = new SolidColorBrush(Colors.DarkGray);
            border1.VerticalAlignment = VerticalAlignment.Bottom;
            border1.Margin = new Thickness(10, 0, 30, 0);

            grid.Children.Add(border1);

            border.Child = grid;

            return border;
        }

        //private static void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("");
        //}
        #region EventBiding

        private static void TexBlockChange(object sender, TextChangedEventArgs e)
        {

            FrameworkElement framework = sender as FrameworkElement;
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "") return;
            if (textBox.Text.EndsWith('.')) return;
            //MessageBox.Show(typeof(TextBox).ToString());
            Grid grid = framework.Parent as Grid;
            double value;
            foreach (var i in grid.Children)
            {
                if (i != null)
                {
                    if (i.GetType() == typeof(Slider))
                    {
                        Slider slider = i as Slider;
                        if (double.TryParse(textBox.Text, out value))
                        {
                            slider.Value = value;
                        }
                        else
                        {
                            textBox.Text = "0";
                        }
                    }
                }

            }
        }

        private static void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FrameworkElement framework = sender as FrameworkElement;
            Slider slider = sender as Slider;

            Grid grid = framework.Parent as Grid;
            foreach (var i in grid.Children)
            {
                if (i != null)
                {
                    if (i.GetType() == typeof(TextBox))
                    {
                        TextBox textbox = i as TextBox;
                        string text = Convert.ToString(Math.Round(slider.Value, 3));
                        if (text == "0") return;
                        textbox.Text = text;
                    }
                }

            }
        }


        #endregion

        private static async Task<Border> RenderItem(object sender, Item i)
        {
            if (i.Type == "Float")
            {
                Border border = await FloatSetting(sender, i);
                return border;
            }
            else if (i.Type == "Bool")
            {
                Border border = await BoolSetting(sender, i);
                return border;
            }
            else if (i.Type == "IntList")
            {
                Border border = await IntSettingList(sender, i);
                return border;
            }
            else if (i.Type == "Keybind")
            {
                Border border = await KeyBindSetting(sender, i);
                return border;
            }
            return null;
        }

        public static async Task<StackPanel> RenderGeneral(Object sender, Group group)
        {
            if (group == null) return null;
            StackPanel stackPanel = new StackPanel();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = group.Name;
            textBlock.FontSize = 17;
            textBlock.Foreground = new SolidColorBrush(Colors.White);
            stackPanel.Children.Add(textBlock);
            stackPanel.Margin = new Thickness(0, 5, 0, 0);
            foreach (var i in group.Items)
            {
                Border border = await RenderItem(sender, i).ConfigureAwait(false);
                if (border != null)
                    stackPanel.Children.Add(border);
            }
            return stackPanel;
        }

        public static async Task<StackPanel> RanderControl(Object sender, Group group)
        {

            StackPanel stackPanel = new();
            MainWindow mainWindow = sender as MainWindow;
            MainWindowViewModel datacontext = mainWindow.DataContext as MainWindowViewModel;

            stackPanel.DataContext = datacontext.NameAgerSele;
            stackPanel.MouseDown += mainWindow.SettingUserView_MouseDown;

            Binding binding = new Binding(".");
            stackPanel.SetBinding(StackPanel.DataContextProperty, binding);

            //stackPanel.DataContext = datacontext.NameAgerSele;

            TextBlock textBlock = new();
            textBlock.Text = group.Name;
            textBlock.FontSize = 17;
            textBlock.Foreground = new SolidColorBrush(Colors.White);
            stackPanel.Children.Add(textBlock);
            stackPanel.Margin = new Thickness(0, 5, 0, 0);
            //stackPanel.MouseDown += StackPanel_MouseDown;

            foreach (var i in group.Items)
            {
                Border border = await RenderItem(sender, i).ConfigureAwait(false);
                if (border != null)
                    stackPanel.Children.Add(border);
            }
            return stackPanel;
        }

        //private static void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("");
        //}
    }
}
