using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.View.Formula;
using Perseverance_Calculator_2.View.Data_SpreadSheet;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Single_Page_Window;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SinglePage_Template_Page : Page
{
    public SinglePage_Template_Page()
    {
        InitializeComponent();
    }

    private void Main_Frame_Loaded(object sender, RoutedEventArgs e)
    {
        Main_Frame.Navigate(typeof(Formula_List_Page));
    }

    private void Page_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        MenuFlyoutItem page = (MenuFlyoutItem)sender;
        if (page.Text.Equals("Formula List"))
        {
            Main_Frame.Navigate(typeof(Formula_List_Page));
        } 
        else if (page.Text.Equals("Custom Buttons"))
        {
            Main_Frame.Navigate(typeof(CustomButtons_Page));
        }
        else if (page.Text.Equals("Data Spreadsheet"))
        {
            Main_Frame.Navigate(typeof(DataSpreadSheet_Page));
        }



        else if (page.Text.Equals("Formula List Project"))
        {
            Main_Frame.Navigate(typeof(Formula_Project_Page));
        }

        else if (page.Text.Equals("Data Spreadsheet Project"))
        {
            Main_Frame.Navigate(typeof(DataSpreadSheet_Project_Page));
        }
    }
}
