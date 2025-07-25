using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Logic.Math;
using Perseverance_Calculator_2.Logic.Window;
using Perseverance_Calculator_2.Logic.Xaml;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using static System.Runtime.InteropServices.JavaScript.JSType;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Formula
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomButtons_Description_Page : Page
    {
        //public static CustomButtons? customButtons;
        public CustomButtons_Description_Page()
        {
            InitializeComponent();
            if (Logic.Window.Window.customButtonDescription_Window != null)
                Logic.Window.Window.customButtonDescription_Window.Closed += CustomButtonDescription_Window_Closed;
        }

        private void CustomButtonDescription_Window_Closed(object sender, WindowEventArgs args)
        {
            Logic.Window.Window.customButtonDescription_Window = null;
        }

        private void TextBox_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            args.Handled = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (IsIgnoreCol_CheckBox.IsChecked == true)
            {
                IsIgnoreCol_StackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                IsIgnoreCol_StackPanel.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void getVar(Model.Formula.Formula formula)
        {
            //if(formula!=null)
            //formula.varFunc_Variable_Dictionary.Clear();
            //formula.Variable_List.Clear();
            //string formulaToSolve = new StringVue().replaceFormulaFunction(formula.Formula_Eq.Replace("\n", "").Replace("\r", "").Replace(" ", ""));
            //Model.Formula.Formula form = new Model.Formula.Formula(formula);
            //foreach (Variable v in new MathVue<double>().getVariables(formulaToSolve, formula, formula.variable_Dictionary))
            //{
            //    formula.Variable_List.Add(v);
            //}





            formula.variable_Dictionary.Clear();
            foreach (var v in formula.Variable_List)
            {
                formula.variable_Dictionary.Add(v.Name, v);
            }
            string formulaToSolve = new StringVue().replaceFormulaFunction(formula.Formula_Eq.Replace("\n", "").Replace("\r", "").Replace(" ", ""));

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
            getVar(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance);
        }

        private void solve(Model.Formula.Formula formula)
        {
            formula.Solution = new MathVue<double>().solveFormula(formula);
        }


        private void FormulaEQ_TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Menu))
            {

                getVar(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance);
                if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count == 0)
                {
                    solve(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance);
                }
            }
        }

        private void VariableValue_TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.Equals(VirtualKey.Menu))
            {
                solve(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance);
            }
        }
        private void SolveAndSetASButton_Button_Click(object sender, RoutedEventArgs e)
        {
            solve(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance);

            if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 0)
            {
                int NumOfVarAdded = 0;
                string use = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name + "(";
                foreach (Variable vars in Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List)
                {
                    if (vars.Name.Equals(vars.VarValue) && !new MathVue<double>().isNumber(vars.VarValue))
                    {
                        NumOfVarAdded++;
                        use += vars.Name + ",";
                    }
                }
                if (!use.EndsWith(','))
                    use += ",";
                use = use.Remove(use.Length - 1) + ")";

                if (NumOfVarAdded > 1)
                {
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                    //isMultiVar = true;
                }
                else if (NumOfVarAdded == 0)
                {
                    use = use.Replace("(", "").Replace(")", "");
                }
                Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = NumOfVarAdded;
                Main_Logic.selection_Model.CustomButtons_Description.Use = use;
            }
            else
            {
                string use = "";
                if (!string.IsNullOrWhiteSpace(NewFormulaName_Tbox.Text))
                    use = NewFormulaName_Tbox.Text;
                else
                    use = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name;
                Main_Logic.selection_Model.CustomButtons_Description.Use = use;
            }
            //Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.ColumnsToIgnore
            if (!string.IsNullOrWhiteSpace(NewFormulaName_Tbox.Text))
            {
                Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                //Model.Formula.CustomButtons customButtons = new Model.Formula.CustomButtons(createButton_Formula);

                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }

                if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }


                if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 1)
                {
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);
                }
                else
                {
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = false;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);

                }
            }
            else
            {
                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }

                if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }


                if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 1)
                {
                    //Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);
                }
                else
                {
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = false;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);

                }
                //if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 1)
                //{
                //    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                //    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary[Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name] = Main_Logic.selection_Model.CustomButtons_Description;
                //}
                //else
                //{
                //    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = false;
                //    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary[Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name] = Main_Logic.selection_Model.CustomButtons_Description;

                //}
            }




        }

        private void RemoveVariablesToIgnore_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBinding varToIgnore = (StringBinding)(((Button)sender).Tag);

                Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.VariablesToIgnore.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.VariablesToIgnore.First(x => x.Equals(varToIgnore)));

        }

        private void RemoveColumnsToIgnore_Button_Click(object sender, RoutedEventArgs e)
        {
            IntBinding colToIgnore = (IntBinding)((Button)sender).Tag;
            Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.ColumnsToIgnore.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.ColumnsToIgnore.First(x => x == colToIgnore));


        }

        private void AddToVariablesToIgnore_Button_Click(object sender, RoutedEventArgs e)
        {
            Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.VariablesToIgnore.Add(new StringBinding());
        }

        private void AddToColumnsToIgnore_Button_Click(object sender, RoutedEventArgs e)
        {
            Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.ColumnsToIgnore.Add(new IntBinding() { Val=-1 });
        }

        private void IsIgnoreCol_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                IsIgnoreCol_StackPanel.Visibility = Visibility.Visible;
            }
        }

        private void IsIgnoreCol_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == false)
            {
                IsIgnoreCol_StackPanel.Visibility = Visibility.Collapsed;
            }

        }

        private void AddVariableToVariableList_Button_Click(object sender, RoutedEventArgs e)
        {
            Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Add(new Variable());
        }

        private void RemoveVar_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Remove((Variable)button.Tag);
        }

        private void SetVariables_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewFormulaName_Tbox.Text))
            {
                Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                //Model.Formula.CustomButtons customButtons = new Model.Formula.CustomButtons(createButton_Formula);

                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }

                if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }


                if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 1)
                {
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);
                }
                else
                {
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = false;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;

                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);

                }
            }
            else
            {
                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }

                if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name))
                {
                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name);
                }


                if (Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count > 1)
                {
                    //Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name = NewFormulaName_Tbox.Text;
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = true;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;
                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);
                }
                else
                {
                    Main_Logic.selection_Model.CustomButtons_Description.IsMultiVarFunction = false;
                    Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.TotalNumberOfColumns = Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Variable_List.Count;
                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(Main_Logic.selection_Model.CustomButtons_Description.Formula_Instance.Name, Main_Logic.selection_Model.CustomButtons_Description);

                }
            }
        }
    }
}
