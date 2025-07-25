using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model.Data_Spreadsheet
{
    public class DataSpreadsheet : NotifyPropChanged_Base
    {

        public DataSpreadsheet() { }

        public DataSpreadsheet(DataSpreadsheet dataSpreadsheet) {
            DataName = dataSpreadsheet.DataName;
            Saved_DataName = dataSpreadsheet.Saved_DataName;
            DataValue = dataSpreadsheet.DataValue;
            DataDescription = dataSpreadsheet.DataDescription;
            EnableSetData = dataSpreadsheet.EnableSetData;
            //EnableSetData = dataSpreadsheet.EnableSetData;
        }

        private string dataName = "";
        private string saved_DataName = "";
        private string dataValue = "";
        private string dataDescription = "";
        private bool enableSetData = true;

        public bool EnableSetData
        {
            get { return enableSetData; }
            set
            {
                enableSetData = value;
                OnPropertyChanged("EnableSetData");
            }
        }

        public string DataName
        {
            get { return dataName; }
            set
            {
                dataName = value;
                OnPropertyChanged("DataName");
            }
        }
        public string Saved_DataName
        {
            get { return saved_DataName; }
            set
            {
                saved_DataName = value;
                OnPropertyChanged("Saved_DataName");
            }
        }
        public string DataValue
        {
            get { return dataValue; }
            set
            {
                dataValue = value;
                OnPropertyChanged("DataValue");
            }
        }
        public string DataDescription
        {
            get { return dataDescription; }
            set
            {
                dataDescription = value;
                OnPropertyChanged("DataDescription");
            }
        }

    }
}
