using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Model.Data_Spreadsheet
{
    public class DataSpreadsheet_Project : NotifyPropChanged_Base
    {
        public DataSpreadsheet_Project() { }
        public DataSpreadsheet_Project(DataSpreadsheet_Project dataSpreadsheet_Project)
        {
            Name = dataSpreadsheet_Project.Name;
            setDataSpreadsheet(dataSpreadsheet_Project);
        }

        private async void setDataSpreadsheet(DataSpreadsheet_Project dataSpreadsheet_Project)
        {

            await Task.Run(() =>
            {
                foreach (DataSpreadsheet spreadsheet in dataSpreadsheet_Project.DataSpreadsheet_List)
                {
                    App._window?.DispatcherQueue.TryEnqueue(() =>
                    {
                        //if (DataSpreadsheet_List != null)
                        //{
                            DataSpreadsheet_List.Add(new DataSpreadsheet(spreadsheet));
                        //}
                        //else
                        //{
                        //    DataSpreadsheet_List = new ObservableCollection<DataSpreadsheet>() { new DataSpreadsheet(spreadsheet) };
                        //}
                    });
                }
            });
        }

        private string name = "";
        private ObservableCollection<DataSpreadsheet> dataSpreadsheet_List = new ObservableCollection<DataSpreadsheet>();
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<DataSpreadsheet> DataSpreadsheet_List
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
