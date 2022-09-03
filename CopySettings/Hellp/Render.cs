using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CopySettings.MVVM.View;
using CopySettings.MVVM.ViewModel;
using System.Windows.Data;
using System.Windows.Media;
using System.Resources;
using System.Reflection.Metadata;
using CopySettings.Obje.GuiObj;

namespace CopySettings.Hellp
{
    public static class Render
    {

        public static async Task<Border> BoolSetting(object sender, Item i)
        {
            var settinview = sender as SettingUserView;
            var datacontext = settinview.DataContext as SettingUserViewModel;
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
            checkBox.Name = i.Name.Replace(' ', '_').Replace(":", String.Empty);
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

        public static async Task<Border> FloatSetting(object sender, Item i)
        {
            var settinview = sender as SettingUserView;
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
            binding_text.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            textBox.SetBinding(TextBox.TextProperty, binding_text);
            textBox.Name = i.Name.Replace(' ', '_').Replace(":", String.Empty);
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

        public static void TexBlockChange(object sender, TextChangedEventArgs e)
        {

            FrameworkElement framework = sender as FrameworkElement;
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "") return;
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

        public static void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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

        public static async Task<Border> RenderItem(object sender , Item i)
        {
            if (i.Type == "Float")
            {
                Border border = await FloatSetting(sender, i);
                return border;
            }
            if (i.Type == "Bool")
            {
                Border border = await BoolSetting(sender, i);
                return border;
            }
            return null;
        }

        public static async Task<StackPanel> RenderGroup(Object sender, Group group)
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


    }
}
