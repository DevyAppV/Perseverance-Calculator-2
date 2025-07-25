using Perseverance_Calculator_2.Model;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Logic.Xaml
{
    public class StringBinding : NotifyPropChanged_Base
    {

        private string val = "";

        public string Val
        {
            get { return val; }
            set
            {
                val = value;
                OnPropertyChanged("Val");
            }
        }
    }
}
