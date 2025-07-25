using Perseverance_Calculator_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Logic.Xaml
{
    public class IntBinding : NotifyPropChanged_Base
    {

        private int val = -1;

        public int Val
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
