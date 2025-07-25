using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Model.Data_Spreadsheet;
using Perseverance_Calculator_2.View.Formula;
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

namespace Perseverance_Calculator_2.View.Data_SpreadSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSpreadSheet_Project_Page : Page
    {


        public DataSpreadSheet_Project_Page()
        {

            InitializeComponent();
        }

        private void AddSpreadsheet_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SpreadsheetName_Tbox.Text))
            {
                Main_Logic.main_Model?.DataSpreadsheet_Project_List.Add(new Model.Data_Spreadsheet.DataSpreadsheet_Project() { Name = SpreadsheetName_Tbox.Text });
            }
        }

        private void Spreadsheet_Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataSpreadSheet_Page.dataSpreadSheet_Page_instance != null)
            {
                ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)((Button)sender).Tag;

                Main_Logic.selection_Model.DataSpreadsheet_List = dataList;

                Main_Logic.selection_Model.SelectedDataSpreadsheet_Name = 
                    Main_Logic.main_Model?.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList).Name;

                //Binding binding = new Binding();
                //binding.Source = dataList;
                //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                //binding.Mode = BindingMode.TwoWay;
                //BindingOperations.SetBinding(DataSpreadSheet_Page.dataSpreadSheet_Page_instance.DataList_ItemsControl, ItemsControl.ItemsSourceProperty, binding);

                //DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag = dataList;
                //DataSpreadSheet_Page.dataSpreadSheet_Page_instance.SelectedSpreadsheet_Name.Text = 
                //    Main_Logic.main_Model?.DataSpreadsheet_Project_List.First(x=>x.DataSpreadsheet_List == dataList).Name;
            }
        }

        private void Spreadsheet_Delete_Button_Click(object sender, RoutedEventArgs e)
        {


            if (DataSpreadSheet_Page.dataSpreadSheet_Page_instance != null)
            {
                ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)((Button)sender).Tag;
                if (Main_Logic.main_Model != null)
                {
                    Model.Data_Spreadsheet.DataSpreadsheet_Project dataSpreadsheet_Project = Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList);

                    Main_Logic.selection_Model?.DataSpreadsheet_List?.Clear();
                    Main_Logic.main_Model.DataSpreadsheet_Project_List.Remove(dataSpreadsheet_Project);
                }
                //DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag = null;
                Main_Logic.selection_Model.SelectedDataSpreadsheet_Name = "Selected Data Spreadsheet";
            }
        }

        private void Spreadsheet_Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

            if (DataSpreadSheet_Page.dataSpreadSheet_Page_instance != null)
            {
                if (DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag != null)
                {
                    ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_TappedButton = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)((Button)sender).Tag;

                    ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_Selected = ((ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag);

                    if (Main_Logic.main_Model != null)
                    {
                        int indexOf_TappedButton = Main_Logic.main_Model.DataSpreadsheet_Project_List.IndexOf(
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_TappedButton));

                        int indexOf_Selected = Main_Logic.main_Model.DataSpreadsheet_Project_List.IndexOf(
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_Selected));


                        Main_Logic.main_Model.DataSpreadsheet_Project_List.Insert(indexOf_TappedButton + 1,
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_Selected));


                        if (indexOf_TappedButton >= indexOf_Selected)
                        {
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.RemoveAt(indexOf_Selected);
                        }
                        else
                        {
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.RemoveAt(indexOf_Selected + 1);
                        }
                    }
                    //Main_Logic.main_Model.DataSpreadsheet_Project_List.Remove(Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_Selected));


                }

            }
        }

    }
}
