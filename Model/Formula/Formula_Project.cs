using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model.Formula
{
    public class Formula_Project : NotifyPropChanged_Base
    {

        public Formula_Project() { }
        public Formula_Project(Formula_Project formula_Project)
        {
            Name = formula_Project.name;
            setFormula_Project(formula_Project);
        }

        private async void setFormula_Project(Formula_Project formula_Project)
        {

            await Task.Run(() =>
            {
                foreach (Formula formula in formula_Project.formula_List)
                {
                    App._window?.DispatcherQueue.TryEnqueue(() =>
                    {
                        formula_List.Add(new Formula(formula));
                    });
                }
            });
        }


        private string name = "";
        private ObservableCollection<Formula> formula_List = new ObservableCollection<Formula>();
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<Formula> Formula_List
        {
            get { return formula_List; }
            set
            {
                formula_List = value;
                OnPropertyChanged("Formula_List");
            }
        }


    }
}
