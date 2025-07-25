using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Model.Data_Spreadsheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Data_SpreadSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSpreadSheet_Page : Page
    {

        public static DataSpreadSheet_Page? dataSpreadSheet_Page_instance;
        public DataSpreadSheet_Page()
        {
            dataSpreadSheet_Page_instance = this;
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //Button? button = sender as Button;
            //if (button != null)
            //{
            //ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataSpreadsheet = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)(button.Tag);
            if (Main_Logic.selection_Model.DataSpreadsheet_List != null)
            {
                Main_Logic.selection_Model.DataSpreadsheet_List.Add(new Model.Data_Spreadsheet.DataSpreadsheet() { });
            }
            //}
        }

        private async void SetData_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                Model.Data_Spreadsheet.DataSpreadsheet dataSpreadsheet = (Model.Data_Spreadsheet.DataSpreadsheet)(button.Tag);


                if (!string.IsNullOrWhiteSpace(dataSpreadsheet.DataName))
                {
                    dataSpreadsheet.EnableSetData = false;
                    if (Main_Logic.main_Model != null && Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(dataSpreadsheet.DataName) &&
                        dataSpreadsheet.Saved_DataName.Equals(dataSpreadsheet.DataName))
                    {
                        Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary[dataSpreadsheet.DataName] = dataSpreadsheet;
                        dataSpreadsheet.Saved_DataName = dataSpreadsheet.DataName;
                    }
                    else if (Main_Logic.main_Model != null && !Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(dataSpreadsheet.DataName) &&
                        Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(dataSpreadsheet.Saved_DataName))
                    {
                        Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.Remove(dataSpreadsheet.Saved_DataName);
                        Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.Add(dataSpreadsheet.DataName, dataSpreadsheet);
                        dataSpreadsheet.Saved_DataName = dataSpreadsheet.DataName;
                    }
                    else if (Main_Logic.main_Model != null && !Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(dataSpreadsheet.DataName) &&
                        !Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(dataSpreadsheet.Saved_DataName))
                    {
                        Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.Add(dataSpreadsheet.DataName, dataSpreadsheet);
                        dataSpreadsheet.Saved_DataName = dataSpreadsheet.DataName;
                    }
                    else
                    {
                        dataSpreadsheet.EnableSetData = false;
                        ContentDialog messageDialog = new ContentDialog
                        {
                            Title = "Error Message",
                            Content = "Error:  Data with the name \"" + dataSpreadsheet.DataName + "\" has already been set.",
                            CloseButtonText = "OK",
                        };
                        messageDialog.XamlRoot = button.XamlRoot;
                        await messageDialog.ShowAsync();
                        dataSpreadsheet.DataName = dataSpreadsheet.Saved_DataName;
                        //await new MessageDialog("Data with the name \"" + dataSpreadsheet.DataName + "\" has already been set.", "Error").ShowAsync();
                        Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Remove(dataSpreadsheet.DataName);
                        dataSpreadsheet.Saved_DataName = "";
                        dataSpreadsheet.EnableSetData = true;
                    }
                }
                else
                {
                    dataSpreadsheet.DataName = dataSpreadsheet.Saved_DataName;
                }

            }
        }

        private void RemoveData_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                Model.Data_Spreadsheet.DataSpreadsheet dataSpreadsheet = (Model.Data_Spreadsheet.DataSpreadsheet)(button.Tag);
                Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Remove(dataSpreadsheet.Saved_DataName);

                if (Main_Logic.main_Model != null)
                {
                    DataSpreadsheet_Project project = Main_Logic.main_Model.DataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List.First(y => y == dataSpreadsheet) != null);

                    if (project != null)
                    {
                        project.DataSpreadsheet_List.Remove(dataSpreadsheet);
                    }
                }
            }

        }

        private void DataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? tbox = sender as TextBox;
            if (tbox != null)
            {
                Model.Data_Spreadsheet.DataSpreadsheet dataSpreadsheet = (Model.Data_Spreadsheet.DataSpreadsheet)(tbox.Tag);
                if (tbox.Name.Equals("DataName_Tbox"))
                {
                    if (!dataSpreadsheet.Saved_DataName.Equals(dataSpreadsheet.DataName) ||
                        string.IsNullOrWhiteSpace(dataSpreadsheet.Saved_DataName))
                    {
                        dataSpreadsheet.EnableSetData = true;
                    }
                }
                else
                {
                    dataSpreadsheet.EnableSetData = true;
                }
            }
        }
    }
}
