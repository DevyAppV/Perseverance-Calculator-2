using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model.Formula
{
    public class CustomButtons_Description : NotifyPropChanged_Base
    {
        private CustomButtons? customButtons_Selected = new CustomButtons();
        public CustomButtons_Description(CustomButtons customButtons_Selected) {
            CustomButtons_Selected = customButtons_Selected;
        }


        public CustomButtons? CustomButtons_Selected
        {
            get { return customButtons_Selected; }
            set
            {
                customButtons_Selected = value;
                OnPropertyChanged("CustomButtons_Selected");
            }
        }


    }
}
