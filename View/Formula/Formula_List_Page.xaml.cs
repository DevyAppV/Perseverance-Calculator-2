using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Logic.Math;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Formula
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Formula_List_Page : Page
    {
        //public static Formula_List_Page? Formula_List_Page_Instance;
        public Formula_List_Page()
        {
            //Formula_List_Page_Instance = this;
            InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{

        //    //Binding binding = new Binding();
        //    //binding.Source = Main_Logic.selectedFormula_List;
        //    //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        //    //binding.Mode = BindingMode.TwoWay;

        //    //BindingOperations.SetBinding(Formula_List_Page.Formula_List_Page_Instance.Formula_List_ItemsControl, ItemsControl.ItemsSourceProperty, binding);

        //    //if (Main_Logic.selectedFormula_List != null)
        //    //{
        //    //    Formula_List_Page.Formula_List_Page_Instance.SelectedProject_TBlock.Text =
        //    //        Main_Logic.main_Model?.Formula_Project_List.First(x => x.Formula_List.Equals(Main_Logic.selectedFormula_List)).Name;
        //    //}
        //    //Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag = Main_Logic.selectedFormula_List;
        //    //Formula_List_Page.Formula_List_Page_Instance.ClearFormula_Button.Tag = Main_Logic.selectedFormula_List;
        //    base.OnNavigatedTo(e);

        //    //ObservableCollection<Model.Formula.Formula> formulaList = (ObservableCollection<Model.Formula.Formula>)((Button)sender).Tag;


        //}

        private void AddFormula_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (((Button)sender).Tag != null)
            //{
            //((ObservableCollection<Model.Formula.Formula>)(((Button)sender).Tag)).Add(new Model.Formula.Formula());
            Main_Logic.selection_Model.SelectedFormula_List.Add(new Model.Formula.Formula());
            //}
        }

        private void ClearFormula_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (((Button)sender).Tag != null)
            //{
            //((ObservableCollection<Model.Formula.Formula>)(((Button)sender).Tag)).Clear();
            Main_Logic.selection_Model.SelectedFormula_List.Clear();
            //}
        }

        private void Formula_Click(object sender, RoutedEventArgs e)
        {
            Model.Formula.Formula formula = (Model.Formula.Formula)((Button)sender).Tag;
            Main_Logic.selectedFormula = formula;
            if (formula.Visibility == Visibility.Visible) { formula.Visibility = Visibility.Collapsed; }
            else { formula.Visibility = Visibility.Visible; }
            //ObservableCollection<Model.Formula.Formula> formulaList = (ObservableCollection<Model.Formula.Formula>)(Formula_List_ItemsControl).Tag;

            //Model.Formula.Formula selectedFormula = Main_Logic.main_Model.formula_Project_List.First(x => x.Formula_List.Equals(formulaList)).Formula_List.First(x => x == formula);
            //.Visibility = Visibility.Visible;
        }

        private void TextBox_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            args.Handled = true;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Formula.Formula createButton_Formula = (Model.Formula.Formula)((Button)sender).Tag;
            //= customButtonsTab_List;

            if (Main_Logic.selection_Model.CustomButtons_Tab_Selected != null)
            {
                createButton(createButton_Formula, ((Button)sender).Content.ToString().Contains("Function"));
            }

        }

        private void createButton(Model.Formula.Formula createButton_Formula, bool isFunction)
        {
            if (Main_Logic.main_Model != null && !Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(createButton_Formula.Name))
            {
                //bool isMultiVar = false;
                if (Main_Logic.customButtons_Tab2_Selected != null)
                {

                    if (!string.IsNullOrWhiteSpace(createButton_Formula.Name))
                    {
                        //TODO: create button and save it to main logic
                        Model.Formula.CustomButtons customButtons = new Model.Formula.CustomButtons(createButton_Formula);
                        if (isFunction)
                        {
                            int NumOfVarAdded = 0;
                            string use = customButtons.Formula_Instance.Name + "(";
                            foreach (Variable vars in createButton_Formula.Variable_List)
                            {
                                if (vars.Name.Equals(vars.VarValue))
                                {
                                    NumOfVarAdded++;
                                    use += vars.Name + ",";
                                }
                            }
                            if (NumOfVarAdded > 1)
                            {
                                customButtons.IsMultiVarFunction = true;
                                //isMultiVar = true;
                            }
                            if (!use.EndsWith(','))
                                use += ",";
                            use = use.Remove(use.Length - 1) + ")";
                            customButtons.Formula_Instance.TotalNumberOfColumns = NumOfVarAdded;
                            customButtons.Use = use;
                        }
                        else
                        {
                            string use = customButtons.Formula_Instance.Name;
                            customButtons.Use = use;
                        }

                        Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Add(customButtons);
                        Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(createButton_Formula.Name, customButtons);

                        if (customButtons.IsMultiVarFunction)
                            Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(createButton_Formula.Name, customButtons);

                    }

                }
                else if (Main_Logic.customButtons_Tab1_Selected != null)
                {

                    if (!string.IsNullOrWhiteSpace(createButton_Formula.Name))
                    {
                        Model.Formula.CustomButtons customButtons = new Model.Formula.CustomButtons(createButton_Formula);
                        if (isFunction)
                        {
                            int NumOfVarAdded = 0;
                            string use = customButtons.Formula_Instance.Name + "(";
                            foreach (Variable vars in createButton_Formula.Variable_List)
                            {
                                if (vars.Name.Equals(vars.VarValue))
                                {
                                    NumOfVarAdded++;
                                    use += vars.Name + ",";
                                }
                            }
                            if (NumOfVarAdded > 1)
                            {
                                customButtons.IsMultiVarFunction = true;
                                //isMultiVar = true;
                            }
                            if (!use.EndsWith(','))
                                use += ",";
                            use = use.Remove(use.Length - 1) + ")";
                            customButtons.Use = use;
                            customButtons.Formula_Instance.TotalNumberOfColumns = NumOfVarAdded;
                        }
                        else
                        {
                            string use = customButtons.Formula_Instance.Name;
                            customButtons.Use = use;
                        }


                        Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Add(customButtons);
                        Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(createButton_Formula.Name, customButtons);

                        if (customButtons.IsMultiVarFunction)
                            Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(createButton_Formula.Name, customButtons);

                    }

                }
                else if (Main_Logic.customButtons_Tab0_Selected != null)
                {

                    if (!string.IsNullOrWhiteSpace(createButton_Formula.Name))
                    {
                        Model.Formula.CustomButtons customButtons = new Model.Formula.CustomButtons(createButton_Formula);
                        if (isFunction)
                        {
                            int NumOfVarAdded = 0;
                            string use = customButtons.Formula_Instance.Name + "(";
                            foreach (Variable vars in createButton_Formula.Variable_List)
                            {
                                if (vars.Name.Equals(vars.VarValue))
                                {
                                    NumOfVarAdded++;
                                    use += vars.Name + ",";
                                }
                            }
                            if (NumOfVarAdded > 1)
                            {
                                customButtons.IsMultiVarFunction = true;
                                //isMultiVar = true;
                            }
                            if (!use.EndsWith(','))
                                use += ",";
                            use = use.Remove(use.Length - 1) + ")";
                            customButtons.Use = use;
                            customButtons.Formula_Instance.TotalNumberOfColumns = NumOfVarAdded;
                        }
                        else
                        {
                            string use = customButtons.Formula_Instance.Name;
                            customButtons.Use = use;
                        }


                        Main_Logic.customButtons_Tab0_Selected?.CustomButtons_List?.Add(customButtons);
                        Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(createButton_Formula.Name, customButtons);

                        if (customButtons.IsMultiVarFunction)
                            Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(createButton_Formula.Name, customButtons);

                    }

                }

            }
        }

        private void FormulaButton_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //if (Formula_List_Page.Formula_List_Page_Instance?.AddFormula_Button.Tag != null)
            //{
                if (Main_Logic.selectedFormula != null)
                {
                    //ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_TappedButton = (ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)((Button)sender).Tag;

                    //ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet> dataList_Selected = ((ObservableCollection<Model.Data_Spreadsheet.DataSpreadsheet>)DataSpreadSheet_Page.dataSpreadSheet_Page_instance.AddData_Button.Tag);

                    //Model.Formula.Formula FormulaProject_TappedButton = (Model.Formula.Formula)((Button)sender).Tag;
                    Model.Formula.Formula formula_TappedButton = (Model.Formula.Formula)((Button)sender).Tag;
                    Model.Formula.Formula Formula_Selected = Main_Logic.selectedFormula;
                    ObservableCollection<Model.Formula.Formula> FormulaProjectList_Selected = Main_Logic.selection_Model.SelectedFormula_List;


                    int indexOf_TappedButton = FormulaProjectList_Selected.IndexOf(FormulaProjectList_Selected.First(x => x == formula_TappedButton));

                    int indexOf_Selected = FormulaProjectList_Selected.IndexOf(
                        FormulaProjectList_Selected.First(x => x == Formula_Selected));


                    FormulaProjectList_Selected.Insert(indexOf_TappedButton + 1,
                        FormulaProjectList_Selected.First(x => x == Formula_Selected));


                    if (indexOf_TappedButton >= indexOf_Selected)
                    {
                        FormulaProjectList_Selected.RemoveAt(indexOf_Selected);
                    }
                    else
                    {
                        FormulaProjectList_Selected.RemoveAt(indexOf_Selected + 1);
                    }
                    //Main_Logic.main_Model.dataSpreadsheet_Project_List.Remove(Main_Logic.main_Model.dataSpreadsheet_Project_List.First(x => x.DataSpreadsheet_List == dataList_Selected));

                    Main_Logic.selectedFormula = null;
                //}
            }
        }

        private void getVar(Model.Formula.Formula formula)
        {
            //if(formula!=null)
            //formula.varFunc_Variable_Dictionary.Clear();
            //formula.Variable_List.Clear();
            string formulaToSolve = new StringVue().replaceFormulaFunction(formula.Formula_Eq.Replace("\n", "").Replace("\r", "").Replace(" ", ""));
            //formulaToSolve = new StringVue().replaceVarFunction(formula, formula.Formula_Eq.Replace("\n", "").Replace("\r", "").Replace(" ", ""));
            //Model.Formula.Formula form = new Model.Formula.Formula(formula);
            //if (formula.variable_Dictionary.Count == 0)
            //{
            formula.variable_Dictionary.Clear();
                foreach (var v in formula.Variable_List)
                {
                    formula.variable_Dictionary.Add(v.Name, v);
                }
            //}
            ObservableCollection<Variable> dat = new MathVue<object>().getVariables(formulaToSolve, formula, formula.variable_Dictionary);

            formula.Variable_List.Clear();
            foreach (Variable v in dat)
            {
                formula.Variable_List.Add(v);
            }
        }
        private void GetVariables_Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Formula.Formula formula = (Model.Formula.Formula)((Button)sender).Tag;
            getVar(formula);

        }
        private void VariableValue_TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Menu))
            {
                Model.Formula.Formula formula = (Model.Formula.Formula)((TextBox)sender).Tag;
                solve(formula);
            }
        }


        private void solve(Model.Formula.Formula formula)
        {
            formula.Solution = new MathVue<double>().solveFormula(formula);
        }
        private void Solve_Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Formula.Formula formula = (Model.Formula.Formula)((Button)sender).Tag;
            solve(formula);
            //formula.lej_Interpreter?.interpret(formula.Formula_Eq);
            //formula.lej_Interpreter?.execute();
        }


        private void FormulaEQ_TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Menu))
            {
                Model.Formula.Formula formula = (Model.Formula.Formula)((TextBox)sender).Tag;
                getVar(formula);
                if (formula.Variable_List.Count == 0)
                {
                    solve(formula);
                }
            }
        }
        private void FormulaEQ_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            Main_Logic.selectedFormula = ((Model.Formula.Formula)(tbox).Tag);
            Main_Logic.selectedFormula_Variable_TextBox_GotFocus = tbox;
        }

        private void VariableValue_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            Main_Logic.selectedFormula_Variable_TextBox_GotFocus = tbox;
            tbox.SelectAll();
        }

        private void DeleteFormula_Button_Click(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<Model.Formula.Formula> formula_List = (ObservableCollection<Model.Formula.Formula>)((Button)sender).Tag;
            Model.Formula.Formula formula = (Model.Formula.Formula)((Button)sender).Tag;

            //ObservableCollection<Model.Formula.Formula> FormulaProjectList_Selected = ((ObservableCollection<Model.Formula.Formula>)Formula_List_Page.Formula_List_Page_Instance.AddFormula_Button.Tag);

            //FormulaProjectList_Selected.Remove(formula);
            Main_Logic.selection_Model.SelectedFormula_List.Remove(formula);
            Main_Logic.selectedFormula_Variable_TextBox_GotFocus = null;
        }
    }
}
