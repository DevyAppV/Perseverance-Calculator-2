using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Data_SpreadSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSpreadSheet_Template_Page : Page
    {
        private bool isDragging = false;
        public DataSpreadSheet_Template_Page()
        {
            InitializeComponent();
        }

        private void DragHandle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            isDragging = true;
            ((UIElement)sender).CapturePointer(e.Pointer);
        }

        private void DragHandle_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            isDragging = false;
            ((UIElement)sender).ReleasePointerCapture(e.Pointer);
        }

        private void DragHandle_Col1_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!isDragging)
                return;

            var position = e.GetCurrentPoint(MainWindow.mainWIndow_Insance?.Main_Grid).Position;
            double newWidth = position.X;

            // Optional: clamp the width to a reasonable range
            newWidth = Math.Max(100, Math.Min(newWidth, MainWindow.mainWIndow_Insance.Main_Grid.ActualWidth - 100));

            DataSpreadsheetProject_Resizable_Col.Width = new GridLength(newWidth, GridUnitType.Pixel);
        }










        private void DataSpreadsheet_Template_FrameColumn0_Loaded(object sender, RoutedEventArgs e)
        {
            DataSpreadsheet_Template_FrameColumn0.Navigate(typeof(DataSpreadSheet_Project_Page));
        }
        private void DataSpreadsheet_Template_FrameColumn1_Loaded(object sender, RoutedEventArgs e)
        {
            DataSpreadsheet_Template_FrameColumn1.Navigate(typeof(DataSpreadSheet_Page));
        }

    }
}
