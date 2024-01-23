﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool eraseMode = false;
        private bool selectMode = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if(inkCanvas != null && colorPicker.SelectedColor.HasValue)
            {
                Color selectedColor = colorpicker.SelectedColor.Value;
                inkCanvas.DefaultDrawingAttributes.Color = selectedColor;
            }
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(inkCanvas != null && thicknessSlider != null)
            {
                inkCanvas.DefaultDrawingAttributes.Width = thicknessSlider.Value;
                inkCanvas.DefaultDrawingAttributes.Height = thicknessSlider.Value;
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            selectMode = !selectMode;

            if (selectMode)
            {
                selectBtn.Background = new SolidColorBrush(Colors.Gray);
                inkCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
            else
            {
                selectBtn.Background = new SolidColorBrush(Colors.Black);
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
        }
    }
}