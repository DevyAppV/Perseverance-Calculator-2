using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Perseverance_Calculator_2.Logic.File;
using Perseverance_Calculator_2.Model.Formula;
using Perseverance_Calculator_2.View.Formula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Logic.Window
{
    public class Window
    {
        //public static CustomButtons_Description_Page customButtons_Description_Page = new CustomButtons_Description_Page();
        //public static CustomButtons_Description_Window customButtons_Description_Window = new CustomButtons_Description_Window();

        public static Microsoft.UI.Xaml.Window ?customButtonDescription_Window = null;
        public static Frame ?customButtonDescription_Frame=null;

        public static void openCustomButtonDescription_Window() {
            if (customButtonDescription_Window == null)
            {
                customButtonDescription_Window = new Microsoft.UI.Xaml.Window ();
                customButtonDescription_Frame = new Frame();
                customButtonDescription_Frame.Navigate(typeof(CustomButtons_Description_Page));
                customButtonDescription_Window.Content = customButtonDescription_Frame;
                customButtonDescription_Window.Activate();
                customButtonDescription_Window.Title = "Perseverance Calculator - " + SaveLoad.fileSavedLoadFile_Name;
            }
            else
            {
                customButtonDescription_Frame?.Navigate(typeof(CustomButtons_Description_Page));
                customButtonDescription_Window.Activate();
            }
            //customButtons_Description_Window.Activate();
            //CustomButtons_Description_Window.customButtons_Description_Window_Instance?.CustomButtons_Description_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding);

        }
    }
}
