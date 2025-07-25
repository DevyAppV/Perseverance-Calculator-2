using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.Storage;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Formula
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Formula_Template_Page : Page
    {
        private bool isDragging = false;
        public Formula_Template_Page()
        {
            //Main_Logic.customButtons_Tab0_Selected = null;
            //Main_Logic.customButtons_Tab1_Selected = null;
            //Main_Logic.customButtons_Tab2_Selected = null;
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

            FormulaProject_Resizable_Col.Width = new GridLength(newWidth, GridUnitType.Pixel);
        }

        private void DragHandle_Col2_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!isDragging)
                return;

            var position = e.GetCurrentPoint(MainWindow.mainWIndow_Insance?.Main_Grid).Position;
            double newWidth = position.X - FormulaProject_Resizable_Col.Width.Value;
            
            // Optional: clamp the width to a reasonable range
            newWidth = Math.Max(100, Math.Min(newWidth, MainWindow.mainWIndow_Insance.Main_Grid.ActualWidth - FormulaProject_Resizable_Col.Width.Value - 100));

            FormulaList_Resizable_Col.Width = new GridLength(newWidth, GridUnitType.Pixel);
        }















        private void Formula_Template_FrameColumn0_Loaded(object sender, RoutedEventArgs e)
        {
            Formula_Template_FrameColumn0.Navigate(typeof(Formula_Project_Page));
        }

        private void Formula_Template_FrameColumn1_Loaded(object sender, RoutedEventArgs e)
        {
            Formula_Template_FrameColumn1.Navigate(typeof(Formula_List_Page));
        }

        private void Formula_Template_FrameColumn2_Loaded(object sender, RoutedEventArgs e)
        {
            Formula_Template_FrameColumn2.Navigate(typeof(CustomButtons_Page));
        }
    }
}
