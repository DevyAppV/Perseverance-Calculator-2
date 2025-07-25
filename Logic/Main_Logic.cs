using Microsoft.UI.Xaml.Controls;
using Perseverance_Calculator_2.Model;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Perseverance_Calculator_2.Logic
{
    public class Main_Logic
    {
        //loaded
        public static Main_Model? main_Model_InitialLoad_ForAppend = new Main_Model();
        public static Main_Model? main_Model = new Main_Model();
        public static Selection_Model? selection_Model = new Selection_Model();

        //Not loaded
        //Clicked formula
        public static TextBox selectedFormula_Variable_TextBox_GotFocus = null;
        public static Formula? selectedFormula = null;
        //public static string? selectedProjectName = "Selected Project";

        //public static ObservableCollection<Model.Formula.Formula>? selectedFormula_List = new ObservableCollection<Formula>();



        public static CustomButtons? customButtons_Btn_ToDelete = null;
        public static CustomButtons_Tab? customButtons_Tab_ToDelete = null;
        public static CustomButtons_Tab? customButtons_Tab0_Selected = null;
        public static CustomButtons_Tab? customButtons_Tab1_Selected = null;
        public static CustomButtons_Tab? customButtons_Tab2_Selected = null;

        //protected override JsonSerializerOptions? GeneratedSerializerOptions() { };


        //public Selection_Model? Selection_Model
        //{
        //    get { return selection_Model; }
        //    set
        //    {
        //        selection_Model = value;
        //        OnPropertyChanged("Selection_Model");
        //    }
        //}


        //public ObservableCollection<Model.Formula.Formula>? SelectedFormula_List
        //{
        //    get { return selectedFormula_List; }
        //    set
        //    {
        //        selectedFormula_List = value;
        //        OnPropertyChanged("SelectedFormula_List");
        //    }
        //}


    }
}
