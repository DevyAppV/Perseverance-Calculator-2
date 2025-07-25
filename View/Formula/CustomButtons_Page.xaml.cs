using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Perseverance_Calculator_2.Logic;
using Perseverance_Calculator_2.Logic.Window;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Perseverance_Calculator_2.View.Formula
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomButtons_Page : Page
    {
        private ContentDialog messageDialog_DelTab = new ContentDialog();
        private ContentDialog messageDialog_DelBtn = new ContentDialog();
        public CustomButtons_Page()
        {
            InitializeComponent();
            messageDialog_DelTab.PrimaryButtonClick += MessageDialog_PrimaryButtonClick_DelTab;
            messageDialog_DelBtn.PrimaryButtonClick += MessageDialog_PrimaryButtonClick_DelBtn;
        }


        private void CreateTab_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTabName_Tbox.Text))
            {
                Main_Logic.main_Model?.CustomButtons_Tab_List.Add(new Model.Formula.CustomButtons_Tab() { Name = NewTabName_Tbox.Text });
            }
        }

        private void CreateSubTab_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTabName_Tbox.Text) && Main_Logic.selection_Model.CustomButtons_Tab_Selected != null)
            {
                CustomButtons_Tab customButtons_Tab = Main_Logic.selection_Model.CustomButtons_Tab_Selected;

                if (customButtons_Tab != null)
                {
                    customButtons_Tab.CustomButtons_SubTab?.Add(new Model.Formula.CustomButtons_Tab() { Name = NewTabName_Tbox.Text });

                    //Binding binding = new Binding();
                    //binding.Source = customButtons_Tab.CustomButtons_SubTab;
                    //binding.Mode = BindingMode.OneWay;

                    if (Main_Logic.customButtons_Tab1_Selected != null && Main_Logic.selection_Model.CustomButtons_Tab2 == null)
                    {
                        Main_Logic.selection_Model.CustomButtons_Tab2 = customButtons_Tab.CustomButtons_SubTab;
                        //SubTab2_ItemsControl?.SetBinding(ItemsControl.ItemsSourceProperty, binding);
                    }

                    else if (Main_Logic.customButtons_Tab0_Selected != null && Main_Logic.selection_Model.CustomButtons_Tab1 == null)
                    {
                        //SubTab1_ItemsControl?.SetBinding(ItemsControl.ItemsSourceProperty, binding);
                        Main_Logic.selection_Model.CustomButtons_Tab1 = customButtons_Tab.CustomButtons_SubTab;
                    }
                }
            }
        }

        //bool isSubTab = false;
        //bool isSubTab1 = false;
        //bool isSubTab2 = false;
        private void Tab_Button_Click(object sender, RoutedEventArgs e)
        {
            //isSubTab1 = false;
            CustomButtons_Tab customButtonsTab_List = (CustomButtons_Tab)((Button)sender).Tag;
            //CreateSubTab_Button.Tag = customButtonsTab_List;
            Main_Logic.selection_Model.CustomButtons_Tab_Selected = customButtonsTab_List;
            //isSubTab = true;


            //Binding binding = new Binding();
            //binding.Source = customButtonsTab_List.CustomButtons_SubTab;
            //binding.Mode = BindingMode.OneWay;

            //SubTab1_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            Main_Logic.selection_Model.CustomButtons_Tab1 = customButtonsTab_List.CustomButtons_SubTab;
            //Binding null_binding = new Binding();
            //SubTab2_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, null_binding);

            Main_Logic.selection_Model.CustomButtons_Tab2 = null;
            Main_Logic.selection_Model.CustomButtons_Tab2 = new ObservableCollection<CustomButtons_Tab>();


            //Binding binding_CustomButtons = new Binding();
            //binding_CustomButtons.Source = customButtonsTab_List.CustomButtons_List;
            //binding_CustomButtons.Mode = BindingMode.OneWay;

            //CustomButtons_List_ItemSource.SetBinding(ItemsControl.ItemsSourceProperty, binding_CustomButtons);

            Main_Logic.selection_Model.CustomButtons_List = customButtonsTab_List.CustomButtons_List;

            Main_Logic.customButtons_Tab0_Selected = customButtonsTab_List;
            Main_Logic.customButtons_Tab1_Selected = null;
            Main_Logic.customButtons_Tab2_Selected = null;



        }

        private void Tab1_Button_Click(object sender, RoutedEventArgs e)
        {
            //isSubTab = false;
            //isSubTab1 = true;
            CustomButtons_Tab customButtonsTab_List = (CustomButtons_Tab)((Button)sender).Tag;
            //CreateSubTab_Button.Tag = customButtonsTab_List;
            Main_Logic.selection_Model.CustomButtons_Tab_Selected = customButtonsTab_List;
            //Binding binding = new Binding();
            //binding.Source = customButtonsTab_List.CustomButtons_SubTab;
            //binding.Mode = BindingMode.OneWay;

            //SubTab2_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            Main_Logic.selection_Model.CustomButtons_Tab2 = customButtonsTab_List.CustomButtons_SubTab;

            //Binding binding_CustomButtons = new Binding();
            //binding_CustomButtons.Source = customButtonsTab_List.CustomButtons_List;
            //binding_CustomButtons.Mode = BindingMode.OneWay;

            //CustomButtons_List_ItemSource.SetBinding(ItemsControl.ItemsSourceProperty, binding_CustomButtons);

            Main_Logic.selection_Model.CustomButtons_List = customButtonsTab_List.CustomButtons_List;
            //Main_Logic.customButtons_Tab0_Selected = new CustomButtons_Tab();
            Main_Logic.customButtons_Tab1_Selected = customButtonsTab_List;
            Main_Logic.customButtons_Tab2_Selected = null;
        }

        private void Tab2_Button_Click(object sender, RoutedEventArgs e)
        {
            //isSubTab = false;
            //isSubTab1 = false;
            //isSubTab2 = true;
            //CreateSubTab_Button.Tag = null;
            CustomButtons_Tab customButtonsTab_List = (CustomButtons_Tab)((Button)sender).Tag;

            //Binding binding_CustomButtons = new Binding();
            //binding_CustomButtons.Source = customButtonsTab_List.CustomButtons_List;
            //binding_CustomButtons.Mode = BindingMode.OneWay;

            //CustomButtons_List_ItemSource.SetBinding(ItemsControl.ItemsSourceProperty, binding_CustomButtons);

            Main_Logic.selection_Model.CustomButtons_List = customButtonsTab_List.CustomButtons_List;

            Main_Logic.customButtons_Tab2_Selected = customButtonsTab_List;
        }

        private void MessageDialog_PrimaryButtonClick_DelBtn(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            //{
            if (Main_Logic.customButtons_Btn_ToDelete != null)
            {
                Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Remove(Main_Logic.customButtons_Btn_ToDelete.Formula_Instance.Name);

                if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(Main_Logic.customButtons_Btn_ToDelete.Formula_Instance.Name))
                    Main_Logic.main_Model?.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(Main_Logic.customButtons_Btn_ToDelete.Formula_Instance.Name);



                if (Main_Logic.customButtons_Tab2_Selected != null)
                {
                    Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Remove(Main_Logic.customButtons_Btn_ToDelete);
                }

                else if (Main_Logic.customButtons_Tab1_Selected != null)
                {
                    Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Remove(Main_Logic.customButtons_Btn_ToDelete);
                }

                else if (Main_Logic.customButtons_Tab0_Selected != null)
                {
                    Main_Logic.customButtons_Tab0_Selected?.CustomButtons_List?.Remove(Main_Logic.customButtons_Btn_ToDelete);
                }

                Main_Logic.customButtons_Btn_ToDelete = null;

                if (Logic.Window.Window.customButtonDescription_Window != null)
                {
                    Logic.Window.Window.customButtonDescription_Window?.Close();
                }
            }
            //}
        }
        private async void CustomButton_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            CustomButtons customButtons = (CustomButtons)((Button)sender).Tag;
            if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            {


                //CustomButtons customButtons = (CustomButtons)((Button)sender).Tag;
                Main_Logic.customButtons_Btn_ToDelete = customButtons;


                messageDialog_DelBtn.Title = "Delete Message";
                messageDialog_DelBtn.Content = "Delete Custom Button: " + customButtons.Formula_Instance.Name + "?";
                messageDialog_DelBtn.PrimaryButtonText = "Yes";
                messageDialog_DelBtn.SecondaryButtonText = "No";
                messageDialog_DelBtn.IsPrimaryButtonEnabled = true;
                messageDialog_DelBtn.IsSecondaryButtonEnabled = true;

                messageDialog_DelBtn.XamlRoot = ((Button)sender).XamlRoot;

                await messageDialog_DelBtn.ShowAsync();


            }
            else
            {
                //Binding binding = new Binding();
                //binding.Source = customButtons;
                //binding.Mode = BindingMode.OneWay;
                Main_Logic.selection_Model.CustomButtons_Description = customButtons;
                Logic.Window.Window.openCustomButtonDescription_Window();
            }

        }

        private async void tabRightTapped(object sender, string customButtonName)
        {
            //isSubTab = false;
            //isSubTab1 = false;
            if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            {
                messageDialog_DelTab.Title = "Delete Message";
                messageDialog_DelTab.Content = "Delete Tab: " + customButtonName + "?";
                messageDialog_DelTab.PrimaryButtonText = "Yes";
                messageDialog_DelTab.SecondaryButtonText = "No";
                messageDialog_DelTab.IsPrimaryButtonEnabled = true;
                messageDialog_DelTab.IsSecondaryButtonEnabled = true;

                messageDialog_DelTab.XamlRoot = ((Button)sender).XamlRoot;

                await messageDialog_DelTab.ShowAsync();

            }

        }
        private void SubTab0Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            {
                CustomButtons_Tab customButtonsTab = (CustomButtons_Tab)((Button)sender).Tag;


                Main_Logic.customButtons_Tab_ToDelete = customButtonsTab;
                Main_Logic.customButtons_Tab0_Selected = customButtonsTab;
                //Main_Logic.customButtons_Tab1_Selected = null;
                //Main_Logic.customButtons_Tab2_Selected = null;
                tabRightTapped(sender, customButtonsTab.Name);
            }
        }
        private void SubTab1Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            {
                CustomButtons_Tab customButtonsTab = (CustomButtons_Tab)((Button)sender).Tag;

                Main_Logic.customButtons_Tab_ToDelete = customButtonsTab;
                Main_Logic.customButtons_Tab1_Selected = customButtonsTab;
                //Main_Logic.customButtons_Tab2_Selected = null;
                tabRightTapped(sender, customButtonsTab.Name);
            }
        }
        private void SubTab2Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
            {
                CustomButtons_Tab customButtonsTab = (CustomButtons_Tab)((Button)sender).Tag;

                Main_Logic.customButtons_Tab_ToDelete = customButtonsTab;
                Main_Logic.customButtons_Tab2_Selected = customButtonsTab;
                tabRightTapped(sender, customButtonsTab.Name);
            }
        }


        private void removeCustomButtonDictionary(string key)
        {
            Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Remove(key);
            if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(key))
                Main_Logic.main_Model?.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Remove(key);
        }
        private void MessageDialog_PrimaryButtonClick_DelTab(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //messageDialog.PrimaryButtonCommand = new CloseTab_Command(Main_Logic.customButtons_Tab_Selected, ref isSubTab, ref isSubTab1);

            Main_Logic.selection_Model.CustomButtons_Tab_Selected = null;
            if (Main_Logic.customButtons_Tab2_Selected != null &&
                Main_Logic.customButtons_Tab_ToDelete == Main_Logic.customButtons_Tab2_Selected)
            {

                foreach (CustomButtons btn in Main_Logic.customButtons_Tab2_Selected.CustomButtons_List)
                {
                    removeCustomButtonDictionary(btn.Formula_Instance.Name);
                }

                Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();
                Main_Logic.customButtons_Tab2_Selected?.CustomButtons_SubTab.Clear();
                if (Main_Logic.main_Model?.CustomButtons_Tab_List.Count > 0)
                {
                    bool found = false;
                    foreach (CustomButtons_Tab tab0 in Main_Logic.main_Model?.CustomButtons_Tab_List)
                    {
                        foreach(CustomButtons_Tab tab1 in tab0.CustomButtons_SubTab)
                        {
                            if (tab1.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab2_Selected))
                            {
                                found=true;
                                tab1.CustomButtons_SubTab.Remove(tab1.CustomButtons_SubTab.First(x => x == Main_Logic.customButtons_Tab2_Selected));
                                break;
                            }
                        }
                        if (found) { break; }
                    }
                }
                Main_Logic.customButtons_Tab2_Selected = null;
                //foreach (CustomButtons btn in Main_Logic.customButtons_Tab2_Selected.CustomButtons_List)
                //{
                //    removeCustomButtonDictionary(btn.Formula_Instance.Name);
                //}




                //Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();

                //if (Main_Logic.customButtons_Tab2_Selected != null)
                //{
                //    if (Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Count > 0)
                //        Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab2_Selected).CustomButtons_SubTab?.Clear();
                //    Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Remove(Main_Logic.customButtons_Tab2_Selected);
                //}
                //Main_Logic.customButtons_Tab2_Selected = null;
            }

            else if (Main_Logic.customButtons_Tab1_Selected != null &&
                Main_Logic.customButtons_Tab_ToDelete == Main_Logic.customButtons_Tab1_Selected)
            {


                foreach (CustomButtons btn in Main_Logic.customButtons_Tab1_Selected.CustomButtons_List)
                {
                    removeCustomButtonDictionary(btn.Formula_Instance.Name);
                }

                foreach (CustomButtons_Tab subtab2 in Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab)
                {
                    for (int i = 0; i < subtab2.CustomButtons_List.Count; i++)
                    {

                        removeCustomButtonDictionary(subtab2.CustomButtons_List[i].Formula_Instance.Name);
                        subtab2.CustomButtons_List.Remove(subtab2.CustomButtons_List[i]);
                        i--;
                    }

                }
                Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Clear();
                Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab.Clear();
                if (Main_Logic.main_Model?.CustomButtons_Tab_List.Count > 0)
                {
                    
                    foreach (CustomButtons_Tab tab0 in Main_Logic.main_Model?.CustomButtons_Tab_List)
                    {
                        if (tab0.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab1_Selected))
                        {
                            tab0.CustomButtons_SubTab.Remove(tab0.CustomButtons_SubTab.First(x=>x== Main_Logic.customButtons_Tab1_Selected));
                            break;
                        }
                    }
                }
                Main_Logic.customButtons_Tab1_Selected = null;

                ////Binding binding = new Binding();
                ////SubTab2_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding);


                //foreach (CustomButtons btn in Main_Logic.customButtons_Tab1_Selected.CustomButtons_List)
                //{
                //    removeCustomButtonDictionary(btn.Formula_Instance.Name);
                //}

                //foreach (CustomButtons_Tab subtab2 in Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab)
                //{

                //    foreach (CustomButtons btn in subtab2.CustomButtons_List)
                //    {
                //        removeCustomButtonDictionary(btn.Formula_Instance.Name);
                //    }

                //}
                ////if (Main_Logic.customButtons_Tab2_Selected != null)
                ////{
                ////    Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();
                ////    if (Main_Logic.customButtons_Tab2_Selected != null)
                ////    {
                ////        if (Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Count > 0)
                ////            Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab2_Selected).CustomButtons_SubTab?.Clear();
                ////        Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Remove(Main_Logic.customButtons_Tab2_Selected);
                ////    }
                ////}
                //Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Clear();
                //if (Main_Logic.customButtons_Tab2_Selected != null && Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab != null &&
                //    Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab2_Selected))
                //{
                //    Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();
                //    Main_Logic.customButtons_Tab2_Selected = null;
                //}

                //if (Main_Logic.customButtons_Tab1_Selected != null)
                //{
                //    if (Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.Count > 0)
                //        Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab1_Selected).CustomButtons_SubTab?.Clear();
                //    Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.Remove(Main_Logic.customButtons_Tab1_Selected);
                //}
                //Main_Logic.customButtons_Tab1_Selected = null;
            }

            else if (Main_Logic.customButtons_Tab0_Selected != null &&
                Main_Logic.customButtons_Tab_ToDelete == Main_Logic.customButtons_Tab0_Selected)
            {

                //Binding binding1 = new Binding();
                //SubTab1_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding1);

                //Binding binding2 = new Binding();
                //SubTab2_ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding2);


                foreach (CustomButtons btn in Main_Logic.customButtons_Tab0_Selected.CustomButtons_List)
                {
                    removeCustomButtonDictionary(btn.Formula_Instance.Name);
                }

                foreach (CustomButtons_Tab subtab1 in Main_Logic.customButtons_Tab0_Selected.CustomButtons_SubTab)
                {
                    for (int i = 0; i < subtab1.CustomButtons_List.Count; i++)
                    {

                        removeCustomButtonDictionary(subtab1.CustomButtons_List[i].Formula_Instance.Name);
                        subtab1.CustomButtons_List.Remove(subtab1.CustomButtons_List[i]);
                        i--;
                    }

                    for (int i = 0; i < subtab1.CustomButtons_SubTab.Count; i++)
                    {
                        foreach (CustomButtons btn in subtab1.CustomButtons_SubTab[i].CustomButtons_List)
                        {
                            removeCustomButtonDictionary(btn.Formula_Instance.Name);
                        }
                        subtab1.CustomButtons_SubTab.Remove(subtab1.CustomButtons_SubTab[i]);
                        i--;
                    }
                    //foreach (CustomButtons_Tab subtab2 in subtab1.CustomButtons_SubTab)
                    //{
                    //    foreach (CustomButtons btn in subtab2.CustomButtons_List)
                    //    {
                    //        removeCustomButtonDictionary(btn.Formula_Instance.Name);
                    //    }
                    //}

                }
                Main_Logic.customButtons_Tab0_Selected?.CustomButtons_List?.Clear();
                Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab.Clear();
                if (Main_Logic.main_Model?.CustomButtons_Tab_List.Count > 0)
                    Main_Logic.main_Model?.CustomButtons_Tab_List?.Remove(Main_Logic.customButtons_Tab0_Selected);
                Main_Logic.customButtons_Tab0_Selected = null;

                //if (Main_Logic.customButtons_Tab1_Selected != null)
                //{
                //    if (Main_Logic.customButtons_Tab2_Selected != null)
                //    {
                //        Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();
                //        if (Main_Logic.customButtons_Tab2_Selected != null)
                //        {
                //            if (Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Count > 0)
                //                Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab2_Selected).CustomButtons_SubTab?.Clear();
                //            Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab?.Remove(Main_Logic.customButtons_Tab2_Selected);
                //        }
                //    }
                //    Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Clear();
                //    if (Main_Logic.customButtons_Tab1_Selected != null)
                //    {
                //        if (Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.Count > 0)
                //            Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab1_Selected).CustomButtons_SubTab?.Clear();
                //        Main_Logic.customButtons_Tab0_Selected?.CustomButtons_SubTab?.Remove(Main_Logic.customButtons_Tab1_Selected);
                //    }
                //}

                //if(Main_Logic.customButtons_Tab0_Selected.CustomButtons_SubTab!=null &&
                //    Main_Logic.customButtons_Tab0_Selected.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab1_Selected))
                //{

                //}

                //if (Main_Logic.customButtons_Tab2_Selected != null && Main_Logic.customButtons_Tab2_Selected.CustomButtons_SubTab != null &&
                //    Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab2_Selected))
                //{
                //    Main_Logic.customButtons_Tab2_Selected?.CustomButtons_List?.Clear();
                //    Main_Logic.customButtons_Tab2_Selected?.CustomButtons_SubTab.Clear();
                //    Main_Logic.customButtons_Tab2_Selected = null;
                //}

                //if (Main_Logic.customButtons_Tab1_Selected!=null && Main_Logic.customButtons_Tab1_Selected.CustomButtons_SubTab!=null &&
                //    Main_Logic.customButtons_Tab0_Selected.CustomButtons_SubTab.Contains(Main_Logic.customButtons_Tab1_Selected))
                //{
                //    Main_Logic.customButtons_Tab1_Selected?.CustomButtons_List?.Clear();
                //    Main_Logic.customButtons_Tab1_Selected?.CustomButtons_SubTab.Clear();
                //    Main_Logic.customButtons_Tab1_Selected = null;
                //}

                //if (Main_Logic.customButtons_Tab0_Selected != null)
                //{
                //    //if (Main_Logic.customButtons_Tab1_Selected != null)();
                //    //    Main_Logic.main_Model.CustomButtons_Tab_List.First(x => x == Main_Logic.customButtons_Tab0_Selected).CustomButtons_SubTab?.First(x => x == Main_Logic.customButtons_Tab1_Selected).CustomButtons_SubTab?.Clear
                //    if (Main_Logic.main_Model?.CustomButtons_Tab_List.Count > 0)
                //        Main_Logic.main_Model.CustomButtons_Tab_List.First(x => x == Main_Logic.customButtons_Tab0_Selected).CustomButtons_SubTab?.Clear();
                //    Main_Logic.main_Model?.CustomButtons_Tab_List?.Remove(Main_Logic.customButtons_Tab0_Selected);
                //}
            }

            GC.Collect();
        }

        private void CustomButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Formula.Formula formula = ((CustomButtons)((Button)sender).Tag).Formula_Instance;

            if (Main_Logic.selectedFormula_Variable_TextBox_GotFocus != null &&
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(formula.Name))
                Main_Logic.selectedFormula_Variable_TextBox_GotFocus.SelectedText = Main_Logic.main_Model.customButtons_SavedButtons_Dictionary[formula.Name].Use;

            else if (Main_Logic.selectedFormula_Variable_TextBox_GotFocus != null &&
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(formula.Name))
                Main_Logic.selectedFormula_Variable_TextBox_GotFocus.SelectedText = Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary[formula.Name].Use;

        }

        private async void GetButtonDesc_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(ButtonName_Tbox.Text))
            {
                Main_Logic.selection_Model.CustomButtons_Description = Main_Logic.main_Model.customButtons_SavedButtons_Dictionary[ButtonName_Tbox.Text];
                Logic.Window.Window.openCustomButtonDescription_Window();
            }
            else if (Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.ContainsKey(ButtonName_Tbox.Text))
            {
                Main_Logic.selection_Model.CustomButtons_Description = Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary[ButtonName_Tbox.Text];
                Logic.Window.Window.openCustomButtonDescription_Window();
            }
            else
            {
                ContentDialog existMessage = new ContentDialog();
                existMessage.Title = "Custom Button Message";
                existMessage.Content = "Button does not exist";
                existMessage.PrimaryButtonText = "OK";
                existMessage.IsPrimaryButtonEnabled = true;
                existMessage.IsSecondaryButtonEnabled = false;

                existMessage.XamlRoot = ((Button)sender).XamlRoot;

                await existMessage.ShowAsync();
            }

        }
    }
}
