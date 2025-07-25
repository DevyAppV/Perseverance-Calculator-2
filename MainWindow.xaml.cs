using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Logic.File;
using Perseverance_Calculator_2.Logic.Math.CustomButtons_Default;
using Perseverance_Calculator_2.Logic.Window;
using Perseverance_Calculator_2.Model;
using Perseverance_Calculator_2.View.Data_SpreadSheet;
using Perseverance_Calculator_2.View.Formula;
using Perseverance_Calculator_2.View.Graphing._2D;
using Perseverance_Calculator_2.View.Single_Page_Window;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Microsoft.UI.Xaml.Window
    {
        public static MainWindow? mainWIndow_Insance;
        public MainWindow()
        {
            InitializeComponent();
            mainWIndow_Insance = this;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            if (App._window_Other.Contains(this))
            {
                App._window_Other.Remove(this);
            }
            else if (App._window.Equals(this))
            {
                if (App._window_Other.Count > 0 && App._window_Other.First() != null)
                {
                    App._window = App._window_Other.First();
                    App._window_Other.Remove(App._window_Other.First());
                }
            }
        }
        private void Main_Frame_Loaded(object sender, RoutedEventArgs e)
        {
            CustomButtons_DefaultList.createDefaultTabs();
            Main_Frame.Navigate(typeof(Formula_Template_Page));
        }

        private void Template_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                if (button.Content.Equals("New Window"))
                {
                    App._window_Other.Add(new MainWindow());
                    App._window_Other.Last()?.Activate();
                }
                if (button.Content.Equals("Single Page"))
                {
                    if (!(Main_Frame.Content is SinglePage_Template_Page currentPage && currentPage.GetType() == typeof(SinglePage_Template_Page)))
                    {
                        Main_Frame.Navigate(typeof(SinglePage_Template_Page));
                    }
                    //Main_Frame.Navigate(typeof(SinglePage_Template_Page));
                }
                else if (button.Content.Equals("Formula"))
                {
                    if (!(Main_Frame.Content is Formula_Template_Page currentPage && currentPage.GetType() == typeof(Formula_Template_Page)))
                    {
                        Main_Frame.Navigate(typeof(Formula_Template_Page));
                    }
                }
                else if (button.Content.Equals("Data Spreadsheet"))
                {
                    if (!(Main_Frame.Content is DataSpreadSheet_Template_Page currentPage && currentPage.GetType() == typeof(DataSpreadSheet_Template_Page)))
                    {
                        Main_Frame.Navigate(typeof(DataSpreadSheet_Template_Page));
                    }
                    //Main_Frame.Navigate(typeof(DataSpreadSheet_Template_Page));
                }
                else if (button.Content.Equals("Graphing 2D"))
                {
                    if (!(Main_Frame.Content is Graphing2D_Template_Page currentPage && currentPage.GetType() == typeof(Graphing2D_Template_Page)))
                    {
                        Main_Frame.Navigate(typeof(Graphing2D_Template_Page));
                    }
                    //Main_Frame.Navigate(typeof(Graphing2D_Template_Page));
                }
            }
        }

        private void SaveAs_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.savePicker();
        }

        //private void clearFormulaList() {

        //    ObservableCollection<Model.Formula.Formula> formulaList_Selected = (ObservableCollection<Model.Formula.Formula>)(Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag);
        //    if (formulaList_Selected != null)
        //    {
        //        formulaList_Selected.Clear();
        //        Formula_List_Page.Formula_List_Page_Instance.SelectedProject_TBlock.Text = "Selected Project";
        //        Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag = null;
        //        Formula_List_Page.Formula_List_Page_Instance.ClearFormula_Button.Tag = null;
        //    }
        //}

        private void LoadFile_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(false, false, false, false, false);
            //clearFormulaList();
        }

        private void LoadFormulaProject_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, false, true, false, false);
            //clearFormulaList();
        }

        private void LoadCustomButtonsProject_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, false, false, true, false);
        }

        private void LoadDataSpreadsheetProject_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, false, false, false, true);
        }

        private void AppendFormulaProject_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, true, false, false, true);
        }

        private void AppendCustomButtonProjects_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, false, false, false, false, true);
        }

        private void AppendDataSpreadsheetProject_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.loadPicker(true, false, false, false, false, false, true);
        }

        private void FontSize_TextBox_TextChanging(object sender, TextBoxTextChangingEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            double fontSize = 0;
            if(double.TryParse((string)(textBox.Text), out fontSize))
            {
                Main_Logic.main_Model.FontSize = fontSize.ToString();
            }
            else
            {
                textBox.Text = "15";
                //Main_Logic.main_Model.FontSize = "15";
            }
        }
    }
}
