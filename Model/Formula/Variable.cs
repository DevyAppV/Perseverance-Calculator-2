using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model.Formula
{
    public class Variable : NotifyPropChanged_Base
    {

        public Variable() { }
        public Variable(
            string name,
            string varValue,
            string description) 
        {
            Name = name;
            VarValue = varValue;
            Description = description;
        }

        private string name = "";
        private string varValue = "";
        private string description = "";


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string VarValue
        {
            get { return varValue; }
            set
            {
                varValue = value;
                OnPropertyChanged("VarValue");
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
