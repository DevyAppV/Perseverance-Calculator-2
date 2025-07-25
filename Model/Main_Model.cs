using Perseverance_Calculator_2.Model.Data_Spreadsheet;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Perseverance_Calculator_2.Model
{
    [JsonSerializable(typeof(Main_Model))]
    public class Main_Model : NotifyPropChanged_Base
    {
        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected override JsonSerializerOptions? GeneratedSerializerOptions => new JsonSerializerOptions()
        //{
        //    PropertyNameCaseInsensitive = true,
        //    WriteIndented = true,


        //};

        //public override JsonTypeInfo? GetTypeInfo(Type type)
        //{
        //    return GeneratedSerializerOptions?.GetTypeInfo(type);
        //}
        //JsonSerializerContext(JsonSerializerOptions? options)
        //{

        //}

        //public Main_Model(JsonSerializerOptions? options) : base(options)
        //{
        //}

        ////public Main_Model() { }
        //public Main_Model(Main_Model? main_Model, JsonSerializerOptions? options) : base(options)
        //{
        //    setMainModel(main_Model);
        //}

        public Main_Model()
        {
        }

        //public Main_Model() { }
        public Main_Model(Main_Model? main_Model)
        {
            setMainModel(main_Model);
        }

        private void setMainModel(Main_Model? main_Model)
        {
            if (main_Model != null)
            {
                formula_Project_List = main_Model.formula_Project_List;
                customButtons_Tab_List = main_Model.customButtons_Tab_List;
                dataSpreadsheet_Project_List = main_Model.dataSpreadsheet_Project_List;
            }
        }

        //public ObservableCollection<string> formula_Template_List = new ObservableCollection<string>() 
        //{ "Formula","Data Spreadsheet", "Graphing" };
        //[XmlElement]

        private ObservableCollection<Formula.Formula_Project> formula_Project_List = new ObservableCollection<Formula.Formula_Project>() { };



        //[XmlElement]
        private ObservableCollection<CustomButtons_Tab> customButtons_Tab_List = new ObservableCollection<CustomButtons_Tab>();
        //(Button name, CustomButtons)
        [XmlIgnore]
        public Dictionary<string, CustomButtons> customButtons_SavedButtons_Dictionary = new Dictionary<string, CustomButtons>();
        [XmlIgnore]
        public Dictionary<string, CustomButtons> customButtons_SavedButtons_IsMultiVariabble_Dictionary = new Dictionary<string, CustomButtons>();



        //[XmlElement]
        private ObservableCollection<DataSpreadsheet_Project> dataSpreadsheet_Project_List = new ObservableCollection<DataSpreadsheet_Project>();
        //(data name, spreadsheet)
        [XmlIgnore]
        public Dictionary<string, DataSpreadsheet> dataSpreadsheet_SavedData_Dictionary = new Dictionary<string, DataSpreadsheet>();



        private string fontSize = "15";

        public string FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }




        public ObservableCollection<DataSpreadsheet_Project> DataSpreadsheet_Project_List
        {
            get { return dataSpreadsheet_Project_List; }
            set
            {
                dataSpreadsheet_Project_List = value;
                OnPropertyChanged("DataSpreadsheet_Project_List");
            }
        }

        public ObservableCollection<CustomButtons_Tab> CustomButtons_Tab_List
        {
            get { return customButtons_Tab_List; }
            set
            {
                customButtons_Tab_List = value;
                OnPropertyChanged("CustomButtons_Tab_List");
            }
        }

        public ObservableCollection<Formula.Formula_Project> Formula_Project_List
        {
            get { return formula_Project_List; }
            set
            {
                formula_Project_List = value;
                OnPropertyChanged("Formula_Project_List");
            }
        }

    }
}
