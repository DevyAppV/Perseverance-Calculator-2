using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Model.Formula;
using Perseverance_Calculator_2.View.Data_SpreadSheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Formula
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Formula_Project_Page : Page
    {
        public Formula_Project_Page()
        {
            InitializeComponent();
        }

        private void AddProject_Button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(ProjectName_Tbox.Text))
            {
                Main_Logic.main_Model?.Formula_Project_List.Add(new Model.Formula.Formula_Project() { Name = ProjectName_Tbox.Text });
            }

        }

        private void ProjectDelete_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Main_Logic.selection_Model.SelectedFormula_List != null)
            {
                ObservableCollection<Model.Formula.Formula> formulaList = (ObservableCollection<Model.Formula.Formula>)((Button)sender).Tag;
                Model.Formula.Formula_Project? formula_Project = null;
                if (Main_Logic.main_Model != null)
                {
                    formula_Project = Main_Logic.main_Model.Formula_Project_List.First(x => x.Formula_List == formulaList);
                }

                //ObservableCollection<Model.Formula.Formula> formulaList_Selected = (ObservableCollection<Model.Formula.Formula>)(Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag);
                if (Main_Logic.selection_Model.SelectedFormula_List != null && Main_Logic.selection_Model.SelectedFormula_List.Equals(formulaList))
                {
                    Main_Logic.selection_Model.SelectedFormula_List.Clear();
                    Main_Logic.selection_Model.SelectedProject_Name = "Selected Project";
                    //Formula_List_Page.Formula_List_Page_Instance.SelectedProject_TBlock.Text = "Selected Project";
                    //Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag = null;
                    //Formula_List_Page.Formula_List_Page_Instance.ClearFormula_Button.Tag = null;
                }
                formulaList.Clear();
                if (Main_Logic.main_Model != null && formula_Project!=null)
                {
                    Main_Logic.main_Model.Formula_Project_List.Remove(formula_Project);
                }

            }

        }

        private void ProjectOpen_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Main_Logic.selection_Model.SelectedFormula_List != null)
            {

                //App._window.Activate();

                ObservableCollection<Model.Formula.Formula> formulaList = (ObservableCollection<Model.Formula.Formula>)((Button)sender).Tag;


                Main_Logic.selection_Model.SelectedFormula_List = formulaList;

                Main_Logic.selection_Model.SelectedProject_Name =
                    Main_Logic.main_Model?.Formula_Project_List.First(x => x.Formula_List.Equals(formulaList)).Name;
                //Binding binding = new Binding();
                //binding.Source = formulaList;
                //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                //binding.Mode = BindingMode.TwoWay;
                //BindingOperations.SetBinding(Formula_List_Page.Formula_List_Page_Instance.Formula_List_ItemsControl, ItemsControl.ItemsSourceProperty, binding);


                //Formula_List_Page.Formula_List_Page_Instance.SelectedProject_TBlock.Text =
                //    Main_Logic.main_Model?.Formula_Project_List.First(x => x.Formula_List.Equals(formulaList)).Name;

                //Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag = formulaList;
                //Formula_List_Page.Formula_List_Page_Instance.ClearFormula_Button.Tag = formulaList;
            }

        }

        private void Project_Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (Main_Logic.selection_Model.SelectedFormula_List != null)
            {
                //if (Main_Logic.selection_Model.SelectedFormula_List?.AddFormula_Button.Tag != null)
                //{
                    //ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_TappedButton = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)((Button)sender).Tag;

                    //ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_Selected = ((ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag);

                    //Model.Formula.Formula FormulaProject_TappedButton = (Model.Formula.Formula)((Button)sender).Tag;
                    ObservableCollection<Model.Formula.Formula> formulaProjectList_TappedButton = (ObservableCollection<Model.Formula.Formula>)((Button)sender).Tag;
                    ObservableCollection<Model.Formula.Formula> FormulaProjectList_Selected = Main_Logic.selection_Model.SelectedFormula_List;

                    if (Main_Logic.main_Model != null)
                    {
                        int indexOf_TappedButton = Main_Logic.main_Model.Formula_Project_List.IndexOf(
                            Main_Logic.main_Model.Formula_Project_List.First(x => x.Formula_List == formulaProjectList_TappedButton));

                        int indexOf_Selected = Main_Logic.main_Model.Formula_Project_List.IndexOf(
                            Main_Logic.main_Model.Formula_Project_List.First(x => x.Formula_List == FormulaProjectList_Selected));


                        Main_Logic.main_Model.Formula_Project_List.Insert(indexOf_TappedButton + 1,
                            Main_Logic.main_Model.Formula_Project_List.First(x => x.Formula_List == FormulaProjectList_Selected));


                        if (indexOf_TappedButton >= indexOf_Selected)
                        {
                            Main_Logic.main_Model.Formula_Project_List.RemoveAt(indexOf_Selected);
                        }
                        else
                        {
                            Main_Logic.main_Model.Formula_Project_List.RemoveAt(indexOf_Selected + 1);
                        }
                        //Main_Logic.main_Model.dataSpreadsheet_Project_List.Remove(Main_Logic.main_Model.dataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_Selected));
                    }

                //}

            }
        }
    }
}
