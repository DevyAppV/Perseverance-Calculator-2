using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model
{
    public class Selection_Model : NotifyPropChanged_Base
    {

        private string? selectedProject_Name = "Selected Project";
        private string? selectedDataSpreadsheet_Name = "Selected Data Spreadsheet";
        private ObservableCollection<Model.Formula.Formula>? selectedFormula_List = new ObservableCollection<Model.Formula.Formula>();
        private ObservableCollection<Data_Spreadsheet.DataSpreadsheet>? dataSpreadsheet_List = new ObservableCollection<Data_Spreadsheet.DataSpreadsheet>();
        private ObservableCollection<CustomButtons>? customButtons_List = new ObservableCollection<CustomButtons>();
        private ObservableCollection<CustomButtons_Tab>? customButtons_Tab0 = new ObservableCollection<CustomButtons_Tab>();
        private ObservableCollection<CustomButtons_Tab>? customButtons_Tab1 = new ObservableCollection<CustomButtons_Tab>();
        private ObservableCollection<CustomButtons_Tab>? customButtons_Tab2 = new ObservableCollection<CustomButtons_Tab>();
        private CustomButtons_Tab? customButtons_Tab_Selected = null;
        //private ObservableCollection<CustomButtons_Tab>? customButtons_List = new ObservableCollection<CustomButtons_Tab>();
        //private ObservableCollection<CustomButtons_Tab>? customButtons_List = new ObservableCollection<CustomButtons_Tab>();
        //private ObservableCollection<CustomButtons>? customButton_List = new ObservableCollection<CustomButtons>();



        private CustomButtons? customButtons_Description = new CustomButtons();
        public CustomButtons_Tab? CustomButtons_Tab_Selected
        {
            get { return customButtons_Tab_Selected; }
            set
            {
                customButtons_Tab_Selected = value;
                OnPropertyChanged("CustomButtons_Tab_Selected");
            }
        }
        public ObservableCollection<CustomButtons_Tab>? CustomButtons_Tab0
        {
            get { return customButtons_Tab0; }
            set
            {
                customButtons_Tab0 = value;
                OnPropertyChanged("CustomButtons_Tab0");
            }
        }
        public ObservableCollection<CustomButtons_Tab>? CustomButtons_Tab1
        {
            get { return customButtons_Tab1; }
            set
            {
                customButtons_Tab1 = value;
                OnPropertyChanged("CustomButtons_Tab1");
            }
        }
        public ObservableCollection<CustomButtons_Tab>? CustomButtons_Tab2
        {
            get { return customButtons_Tab2; }
            set
            {
                customButtons_Tab2 = value;
                OnPropertyChanged("CustomButtons_Tab2");
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
        public CustomButtons? CustomButtons_Description
        {
            get { return customButtons_Description; }
            set
            {
                customButtons_Description = value;
                OnPropertyChanged("CustomButtons_Description");
            }
        }
        public string? SelectedProject_Name
        {
            get { return selectedProject_Name; }
            set
            {
                selectedProject_Name = value;
                OnPropertyChanged("SelectedProject_Name");
            }
        }

        public string? SelectedDataSpreadsheet_Name
        {
            get { return selectedDataSpreadsheet_Name; }
            set
            {
                selectedDataSpreadsheet_Name = value;
                OnPropertyChanged("SelectedDataSpreadsheet_Name");
            }
        }


        public ObservableCollection<Model.Formula.Formula>? SelectedFormula_List
        {
            get { return selectedFormula_List; }
            set
            {
                selectedFormula_List = value;
                OnPropertyChanged("SelectedFormula_List");
            }
        }

        public ObservableCollection<Data_Spreadsheet.DataSpreadsheet>? DataSpreadsheet_List
        {
            get { return dataSpreadsheet_List; }
            set
            {
                dataSpreadsheet_List = value;
                OnPropertyChanged("DataSpreadsheet_List");
            }
        }

    }
}
