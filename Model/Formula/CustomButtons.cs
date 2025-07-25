using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Perseverance_Calculator_2.Model.Formula
{

    public class CustomButtons_Tab : NotifyPropChanged_Base
    {

        public CustomButtons_Tab() { }
        public CustomButtons_Tab(CustomButtons_Tab customButtons_Tab)
        {

            Name = customButtons_Tab.Name;
            setCustomButtons_Tab(customButtons_Tab);
        }

        private async void setCustomButtons_Tab(CustomButtons_Tab customButtons_Tab)
        {

            if (customButtons_Tab.CustomButtons_List != null)
            {
                await Task.Run(() =>
                {
                    foreach (CustomButtons customButton in customButtons_Tab.CustomButtons_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(() =>
                        {
                            CustomButtons_List?.Add(new CustomButtons(customButton.Formula_Instance));
                        });
                    }
                });
            }
            if (customButtons_Tab.CustomButtons_SubTab != null)
            {
                await Task.Run(() =>
                {
                    foreach (CustomButtons_Tab customButton_Tab in customButtons_Tab.CustomButtons_SubTab)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(() =>
                        {
                            CustomButtons_SubTab?.Add(new CustomButtons_Tab(customButton_Tab));
                        });
                    }
                });
            }

        }


        private string name = "";

        private ObservableCollection<CustomButtons>? customButtons_List = new ObservableCollection<CustomButtons>();


        private ObservableCollection<CustomButtons_Tab>? customButtons_SubTab = new ObservableCollection<CustomButtons_Tab>();

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<CustomButtons>? CustomButtons_List
        {
            get { return customButtons_List; }
            set
            {
                customButtons_List = value;
                OnPropertyChanged("CustomButtons_List");
            }
        }
        public ObservableCollection<CustomButtons_Tab>? CustomButtons_SubTab
        {
            get { return customButtons_SubTab; }
            set
            {
                customButtons_SubTab = value;
                OnPropertyChanged("CustomButtons_SubTab");
            }
        }
    }

    public class CustomButtons : NotifyPropChanged_Base
    {

        //string name,
        //    string formula,
        //    string rearrangedFormula_BeforCalculation,
        //    string solution,
        //    string description,
        //    ObservableCollection<Variable> variable_List
        private Formula formula_Instance = new Formula();
        public CustomButtons() { }
        public CustomButtons(Formula formula)
        {
            formula_Instance.Name = formula.Name;
            formula_Instance.Formula_Eq = formula.Formula_Eq;
            formula_Instance.RearrangedFormula_BeforCalculation = formula.RearrangedFormula_BeforCalculation;
            formula_Instance.Solution = formula.Solution;
            formula_Instance.Description = formula.Description;

            //foreach (ObservableCollection<string> v in formula.SolutionGrid_MultiArray)
            //{
            //    formula_Instance.SolutionGrid_MultiArray.Add(new ObservableCollection<string>());
            //    foreach (string s in v)
            //    {
            //        formula_Instance.SolutionGrid_MultiArray.Last().Add(s);
            //    }
            //}

            foreach (Variable v in formula.Variable_List)
            {
                formula_Instance.Variable_List.Add(v);
            }
        }
        public CustomButtons(Formula formula, string use)
        {
            formula_Instance.Name = formula.Name;
            formula_Instance.Formula_Eq = formula.Formula_Eq;
            formula_Instance.RearrangedFormula_BeforCalculation = formula.RearrangedFormula_BeforCalculation;
            formula_Instance.Solution = formula.Solution;
            formula_Instance.Description = formula.Description;
            Use = use;

            //foreach (ObservableCollection<string> v in formula.SolutionGrid_MultiArray)
            //{
            //    formula_Instance.SolutionGrid_MultiArray.Add(new ObservableCollection<string>());
            //    foreach (string s in v)
            //    {
            //        formula_Instance.SolutionGrid_MultiArray.Last().Add(s);
            //    }
            //}

            foreach (Variable v in formula.Variable_List)
            {
                formula_Instance.Variable_List.Add(v);
            }
        }
        public CustomButtons(Formula formula, string use, bool isMultiVarFunction)
        {
            formula_Instance.Name = formula.Name;
            formula_Instance.Formula_Eq = formula.Formula_Eq;
            formula_Instance.RearrangedFormula_BeforCalculation = formula.RearrangedFormula_BeforCalculation;
            formula_Instance.Solution = formula.Solution;
            formula_Instance.Description = formula.Description;
            Use = use;
            IsMultiVarFunction = isMultiVarFunction;

            //foreach (ObservableCollection<string> v in formula.SolutionGrid_MultiArray)
            //{
            //    formula_Instance.SolutionGrid_MultiArray.Add(new ObservableCollection<string>());
            //    foreach (string s in v)
            //    {
            //        formula_Instance.SolutionGrid_MultiArray.Last().Add(s);
            //    }
            //}

            foreach (Variable v in formula.Variable_List)
            {
                formula_Instance.Variable_List.Add(v);
            }
        }


        //Behaviors
        //private bool isOperator = false;
        //private bool isConstant = false;
        //private bool isVariable = false;
        //private bool isFunction = false;
        private string use = "";
        private bool isMultiVarFunction = false;
        //private (bool, List<string> variablesToIgnore, List<int> columnsToIgnore, int totalNumberOfColumns, bool ignoreAllVar) ignoreColumns;

        //private CustomButtons_IsOperator_Behavior? customButtons_IsOperator_Behavior = null;
        //private CustomButtons_IsConstant_Behavior? customButtons_IsConstant_Behavior = null;
        //private CustomButtons_IsVariable_Behavior? customButtons_IsVariable_Behavior = null;
        //private CustomButtons_IsFunction_Behavior? customButtons_IsFunction_Behavior = null;

        //public (bool, List<string> variablesToIgnore, List<int> columnsToIgnore, int totalNumberOfColumns, bool ignoreAllVar) IgnoreColumns
        //{
        //    get { return ignoreColumns; }
        //    set
        //    {
        //        ignoreColumns = value;
        //        OnPropertyChanged("IgnoreColumns");
        //    }
        //}

        public bool IsMultiVarFunction
        {
            get { return isMultiVarFunction; }
            set
            {
                isMultiVarFunction = value;
                OnPropertyChanged("IsMultiVarFunction");
            }
        }

        public string Use
        {
            get { return use; }
            set
            {
                use = value;
                OnPropertyChanged("Use");
            }
        }
        //public CustomButtons_IsOperator_Behavior? CustomButtons_IsOperator_Behavior
        //{
        //    get { return customButtons_IsOperator_Behavior; }
        //    set
        //    {
        //        customButtons_IsOperator_Behavior = value;
        //        OnPropertyChanged("CustomButtons_IsOperator_Behavior");
        //    }
        //}


        //public CustomButtons_IsConstant_Behavior? CustomButtons_IsConstant_Behavior
        //{
        //    get { return customButtons_IsConstant_Behavior; }
        //    set
        //    {
        //        customButtons_IsConstant_Behavior = value;
        //        OnPropertyChanged("CustomButtons_IsConstant_Behavior");
        //    }
        //}


        //public CustomButtons_IsVariable_Behavior? CustomButtons_IsVariable_Behavior
        //{
        //    get { return customButtons_IsVariable_Behavior; }
        //    set
        //    {
        //        customButtons_IsVariable_Behavior = value;
        //        OnPropertyChanged("CustomButtons_IsVariable_Behavior");
        //    }
        //}


        //public CustomButtons_IsFunction_Behavior? CustomButtons_IsFunction_Behavior
        //{
        //    get { return customButtons_IsFunction_Behavior; }
        //    set
        //    {
        //        customButtons_IsFunction_Behavior = value;
        //        OnPropertyChanged("CustomButtons_IsFunction_Behavior");
        //    }
        //}

        //public bool IsOperator
        //{
        //    get { return isOperator; }
        //    set
        //    {
        //        isOperator = value;
        //        OnPropertyChanged("IsOperator");
        //    }
        //}

        //public bool IsConstant
        //{
        //    get { return isConstant; }
        //    set
        //    {
        //        isConstant = value;
        //        OnPropertyChanged("IsConstant");
        //    }
        //}

        //public bool IsVariable
        //{
        //    get { return isVariable; }
        //    set
        //    {
        //        isVariable = value;
        //        OnPropertyChanged("IsVariable");
        //    }
        //}

        //public bool IsFunction
        //{
        //    get { return isFunction; }
        //    set
        //    {
        //        isFunction = value;
        //        OnPropertyChanged("IsFunction");
        //    }
        //}

        public Formula Formula_Instance
        {
            get { return formula_Instance; }
            set
            {
                formula_Instance = value;
                OnPropertyChanged("Formula_Instance");
            }
        }

    }
    public class CustomButtons_IsOperator_Behavior : NotifyPropChanged_Base
    {
        //pemdas
        private string orderOfOperation_OccursAfterWhichOperator = "";

        private string custom_Interpreter = "";


        public string OrderOfOperation_OccursAfterWhichOperator
        {
            get { return orderOfOperation_OccursAfterWhichOperator; }
            set
            {
                orderOfOperation_OccursAfterWhichOperator = value;
                OnPropertyChanged("OrderOfOperation_OccursAfterWhichOperator");
            }
        }

        public string Custom_Interpreter
        {
            get { return custom_Interpreter; }
            set
            {
                custom_Interpreter = value;
                OnPropertyChanged("Custom_Interpreter");
            }
        }


    }
    public class CustomButtons_IsConstant_Behavior : NotifyPropChanged_Base
    {

        private string custom_Interpreter = "";

        public string Custom_Interpreter
        {
            get { return custom_Interpreter; }
            set
            {
                custom_Interpreter = value;
                OnPropertyChanged("Custom_Interpreter");
            }
        }
    }
    public class CustomButtons_IsVariable_Behavior : NotifyPropChanged_Base
    {

        private string custom_Interpreter = "";

        public string Custom_Interpreter
        {
            get { return custom_Interpreter; }
            set
            {
                custom_Interpreter = value;
                OnPropertyChanged("Custom_Interpreter");
            }
        }
    }
    public class CustomButtons_IsFunction_Behavior : NotifyPropChanged_Base
    {
        private string custom_Interpreter = "";

        public string Custom_Interpreter
        {
            get { return custom_Interpreter; }
            set
            {
                custom_Interpreter = value;
                OnPropertyChanged("Custom_Interpreter");
            }
        }
    }
}
