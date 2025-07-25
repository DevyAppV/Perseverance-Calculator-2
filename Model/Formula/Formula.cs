using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Perseverance_Calculator_2.Interpreter;
using Perseverance_Calculator_2.Logic.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.ApplicationModel.Activation;

namespace Perseverance_Calculator_2.Model.Formula
{
    public class Formula : NotifyPropChanged_Base
    {
        public Formula()
        {
            //lej_Interpreter = new Lej_Interpreter(Variable_List);
        }
        public Formula(Formula formula)
        {

            Name = formula.Name;
            Formula_Eq = formula.Formula_Eq;
            RearrangedFormula_BeforCalculation = formula.RearrangedFormula_BeforCalculation;
            Solution = formula.Solution;
            Description = formula.Description;
            //Asymptote = formula.Asymptote;
            //Period = formula.Period;
            //Variable_List = variable_List;
            //SolutionGrid_MultiArray = solutionGrid_MultiArray;
            setFormula(formula);
            //lej_Interpreter = new Lej_Interpreter(Variable_List);

        }


        private async void setFormula(Formula formula)
        {

            await Task.Run(() =>
            {
                //foreach (ObservableCollection<string> v in formula.SolutionGrid_MultiArray)
                //{
                //    App._window?.DispatcherQueue.TryEnqueue(() =>
                //    {
                //        SolutionGrid_MultiArray.Add(new ObservableCollection<string>());
                //    });
                //    foreach (string s in v)
                //    {
                //        App._window?.DispatcherQueue.TryEnqueue(() =>
                //        {
                //            SolutionGrid_MultiArray.Last().Add(s);
                //        });
                //    }
                //}
                App._window?.DispatcherQueue.TryEnqueue( () =>
                {
                        variable_Dictionary.Clear();
                });
                foreach (Variable v in formula.Variable_List)
                {
                    App._window?.DispatcherQueue.TryEnqueue(() =>
                    {
                        Variable_List.Add(v);
                        variable_Dictionary.Add(v.Name, v);
                    });
                }
            });
        }
        public Formula(
            string name,
            string formula,
            string rearrangedFormula_BeforCalculation,
            string solution,
            string description,
            string asymptote,
            string period,
            ObservableCollection<Variable> variable_List,
            ObservableCollection<ObservableCollection<string>> solutionGrid_MultiArray
            )
        {
            Name = name;
            Formula_Eq = formula_Eq;
            RearrangedFormula_BeforCalculation = rearrangedFormula_BeforCalculation;
            Solution = solution;
            Description = description;
            //Asymptote = asymptote;
            //Period = period;

            //foreach (ObservableCollection<string> v in solutionGrid_MultiArray)
            //{
            //    SolutionGrid_MultiArray.Add(new ObservableCollection<string>());
            //    foreach (string s in v)
            //    {
            //        SolutionGrid_MultiArray.Last().Add(s);
            //    }
            //}
            variable_Dictionary.Clear();

            foreach (Variable v in variable_List)
            {
                Variable_List.Add(v);
                variable_Dictionary.Add(v.Name, v);
            }
            //lej_Interpreter = new Lej_Interpreter(Variable_List);
            //lej_Interpreter = new Lej_Interpreter(Variable_List);
        }

        //[XmlIgnore]
        //public Lej_Interpreter? lej_Interpreter = new Lej_Interpreter();

        private string name = "";
        private string formula_Eq = "";
        private string rearrangedFormula_BeforCalculation = "";
        private string solution = "";
        private string description = "";


        //private string asymptote = "NaN";
        //private string period = "";
        //private bool isFunction = false;
        #region CustomButtons Only


        #region ignore COL
        //===========Ignore COL
        private bool isIgnoreCol = false;
        private ObservableCollection<StringBinding> variablesToIgnore = new ObservableCollection<StringBinding>() { };
        private ObservableCollection<IntBinding> columnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val=-1 }  };
        private int totalNumberOfColumns = -1;//isSet through coding
        private bool ignoreAllVar = false;
        private bool paramValCanBeSet_DuringCalc = false;
        //===========Ignore COL
        #endregion ignore COL



        #endregion CustomButtons Only

        private Visibility visibility = Visibility.Collapsed;

        [XmlIgnore]
        //public Dictionary<string, string> varFunc_Variable_Dictionary = new Dictionary<string, string>();
        public Dictionary<string, Variable> variable_Dictionary = new Dictionary<string, Variable>();
        ObservableCollection<Variable> variable_List = new ObservableCollection<Variable>();
        //ObservableCollection<ObservableCollection<string>> solutionGrid_MultiArray = new ObservableCollection<ObservableCollection<string>>();

        //public bool IsFunction
        //{
        //    get { return isFunction; }
        //    set
        //    {
        //        isFunction = value;
        //        OnPropertyChanged("IsFunction");
        //    }
        //}

        public bool ParamValCanBeSet_DuringCalc
        {
            get { return paramValCanBeSet_DuringCalc; }
            set
            {
                paramValCanBeSet_DuringCalc = value;
                OnPropertyChanged("ParamValCanBeSet_DuringCalc");
            }
        }
        

        public bool IgnoreAllVar
        {
            get { return ignoreAllVar; }
            set
            {
                ignoreAllVar = value;
                OnPropertyChanged("IgnoreAllVar");
            }
        }

        public int TotalNumberOfColumns
        {
            get { return totalNumberOfColumns; }
            set
            {
                totalNumberOfColumns = value;
                OnPropertyChanged("TotalNumberOfColumns");
            }
        }

        public ObservableCollection<IntBinding> ColumnsToIgnore
        {
            get { return columnsToIgnore; }
            set
            {
                columnsToIgnore = value;
                OnPropertyChanged("ColumnsToIgnore");
            }
        }

        public ObservableCollection<StringBinding> VariablesToIgnore
        {
            get { return variablesToIgnore; }
            set
            {
                variablesToIgnore = value;
                OnPropertyChanged("VariablesToIgnore");
            }
        }

        public bool IsIgnoreCol
        {
            get { return isIgnoreCol; }
            set
            {
                isIgnoreCol = value;
                OnPropertyChanged("IsIgnoreCol");
            }
        }

        //public ObservableCollection<ObservableCollection<string>> SolutionGrid_MultiArray
        //{
        //    get { return solutionGrid_MultiArray; }
        //    set
        //    {
        //        solutionGrid_MultiArray = value;
        //        OnPropertyChanged("SolutionGrid_MultiArray");
        //    }
        //}

        public ObservableCollection<Variable> Variable_List
        {
            get { return variable_List; }
            set
            {
                variable_List = value;
                OnPropertyChanged("Variable_List");
            }
        }

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        //public string Period
        //{
        //    get { return period; }
        //    set
        //    {
        //        period = value;
        //        OnPropertyChanged("Period");
        //    }
        //}

        //public string Asymptote
        //{
        //    get { return asymptote; }
        //    set
        //    {
        //        asymptote = value;
        //        OnPropertyChanged("Asymptote");
        //    }
        //}

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Formula_Eq
        {
            get { return formula_Eq; }
            set
            {
                formula_Eq = value;
                OnPropertyChanged("Formula_Eq");
            }
        }
        public string RearrangedFormula_BeforCalculation
        {
            get { return rearrangedFormula_BeforCalculation; }
            set
            {
                rearrangedFormula_BeforCalculation = value;
                OnPropertyChanged("RearrangedFormula_BeforCalculation");
            }
        }
        public string Solution
        {
            get { return solution; }
            set
            {
                solution = value;
                OnPropertyChanged("Solution");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}
