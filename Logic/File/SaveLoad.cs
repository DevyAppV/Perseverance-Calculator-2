using Microsoft.UI.Xaml.Controls;
using Perseverance_Calculator_2.Model;
using Perseverance_Calculator_2.Model.Data_Spreadsheet;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using WinRT.Interop;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Perseverance_Calculator_2.Logic.File
{
    public class SaveLoad
    {
        public static string fileSavedLoadFile_Name = "";
        public static async void savePicker()
        {
            FileSavePicker picker = new Windows.Storage.Pickers.FileSavePicker();

            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            picker.FileTypeChoices.Add("XML Perseverance Calculator", new List<string>() { ".xml" });
            picker.SuggestedFileName = fileSavedLoadFile_Name;



            nint windowHandle = WindowNative.GetWindowHandle(App._window);
            InitializeWithWindow.Initialize(picker, windowHandle);

            Windows.Storage.StorageFile file = await picker.PickSaveFileAsync();
            //Task t = Task.Run(() => { });

            if (file != null)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Async = true;
                settings.Encoding = Encoding.UTF8;
                settings.OmitXmlDeclaration = false;
                StringBuilder builder = new StringBuilder();

                XmlSerializer serializer = new XmlSerializer(typeof(Main_Model));

                using (XmlWriter writer = XmlWriter.Create(builder, settings))
                    serializer.Serialize(writer, Main_Logic.main_Model);
                fileSavedLoadFile_Name = file.DisplayName;

                App._window.Title = "Perseverance Calculator - " + fileSavedLoadFile_Name;

                while (true)
                {
                    try
                    {
                        //await Task.Run(async() => {
                        CachedFileManager.DeferUpdates(file);
                        await Windows.Storage.FileIO.WriteTextAsync(file, builder.ToString(), encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8);
                        //});
                        break;
                    }
                    catch
                    {
                        await Task.Delay(1000);
                    }
                }

                if (await CachedFileManager.CompleteUpdatesAsync(file) == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                }
            }

        }



        public static async void loadPicker(bool isForAppending_OrLoadOnly,
            bool appendFormulaProject = false, bool loadOnly_FormulaProject = false, bool loadOnly_CustomButton = false, bool loadOnly_DataSpreadsheet = false,
            bool appendCustomButtonsProject = false, bool appendDataSpreadSheetProject = false)
        {
            FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            //picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            //picker.SuggestedStartLocation = ApplicationData.Current.LocalFolder;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;


            picker.FileTypeFilter.Add(".xml");
            nint windowHandle = WindowNative.GetWindowHandle(App._window);

            InitializeWithWindow.Initialize(picker, windowHandle);

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            //Task t = Task.Run(() => { });


            if (file != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Main_Model));

                string data = "";

                while (true)
                {
                    try
                    {
                        //await Task.Run(async () =>
                        //{
                        CachedFileManager.DeferUpdates(file);
                        data = await FileIO.ReadTextAsync(file);
                        //});
                        break;
                    }
                    catch { await Task.Delay(1000); }
                }

                CachedFileManager.DeferUpdates(file);
                using (StringReader reader = new StringReader(data))
                {
                    if (!isForAppending_OrLoadOnly)
                    {
                        fileSavedLoadFile_Name = file.DisplayName;
                        App._window.Title = "Perseverance Calculator - " + fileSavedLoadFile_Name;
                        Main_Model? model = (Main_Model?)serializer.Deserialize(reader);
                        setLoaded_MainModel(model);
                        Main_Logic.selection_Model.SelectedFormula_List = null;
                        Main_Logic.selection_Model.SelectedFormula_List = new ObservableCollection<Formula>();
                        Main_Logic.selection_Model.SelectedProject_Name = "Selected Project";
                    }
                    else
                    {
                        Main_Logic.main_Model_InitialLoad_ForAppend = (Main_Model?)serializer.Deserialize(reader);
                    }

                }

                if (await CachedFileManager.CompleteUpdatesAsync(file) == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    setCustomButtons_andData();

                    if (appendFormulaProject)
                    {
                        appendFormulaProjects();
                    }
                    else if (appendCustomButtonsProject)
                    {
                        appendCustomButtonsProjects();
                    }
                    else if (loadOnly_FormulaProject)
                    {
                        loadOnly_FormulaProjects();
                        Main_Logic.selection_Model.SelectedFormula_List = null;
                        Main_Logic.selection_Model.SelectedFormula_List = new ObservableCollection<Formula>();
                        Main_Logic.selection_Model.SelectedProject_Name = "Selected Project";
                    }
                    else if (loadOnly_CustomButton)
                    {
                        loadOnly_CustomButtons();
                    }
                    else if (loadOnly_DataSpreadsheet)
                    {
                        loadOnly_DataSpreadsheetProjects();
                        Main_Logic.selection_Model.DataSpreadsheet_List = null;
                        Main_Logic.selection_Model.SelectedFormula_List = new ObservableCollection<Formula>();
                        Main_Logic.selection_Model.SelectedDataSpreadsheet_Name = "Selected Project";
                    }
                    else if (appendDataSpreadSheetProject)
                    {
                        append_DataSpreadsheetProjects();
                    }
                }
            }
        }


        private static async void appendCustomButtonProjects_Support(CustomButtons_Tab customButtons_Tab_Loaded, CustomButtons_Tab customButtons_Tab_Current)
        {

            await Task.Run(() =>
            {


                foreach (CustomButtons btn in customButtons_Tab_Loaded.CustomButtons_List)
                {
                    if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(btn.Formula_Instance.Name))
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            customButtons_Tab_Current.CustomButtons_List.Add(btn);
                            Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(btn.Formula_Instance.Name, btn);

                            if (btn.Formula_Instance.Variable_List.Count > 1)
                            {
                                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(btn.Formula_Instance.Name, btn);
                            }
                        });
                    }
                }



            });
        }

        private static async void appendCustomButtonsProjects()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                Task t = Task.Run(() =>
                {

                    ObservableCollection<CustomButtons_Tab> loaded_Tabs = Main_Logic.main_Model_InitialLoad_ForAppend.CustomButtons_Tab_List;

                    foreach (CustomButtons_Tab loadded_Tab0 in loaded_Tabs)
                    {
                        //bool containsInTab = false;
                        bool containsInTab0 = false;

                        for (int i = 0; i < Main_Logic.main_Model?.CustomButtons_Tab_List.Count; i++)
                        {
                            if (Main_Logic.main_Model.CustomButtons_Tab_List[i].Name.Equals(loadded_Tab0.Name))
                            {
                                foreach (CustomButtons_Tab loadded_Tab1 in loadded_Tab0.CustomButtons_SubTab)
                                {
                                    bool containsInTab1 = false;
                                    for (int q = 0; q < Main_Logic.main_Model?.CustomButtons_Tab_List[i].CustomButtons_SubTab.Count; q++)
                                    {
                                        if (Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].Name.Equals(loadded_Tab1.Name))
                                        {
                                            foreach (CustomButtons_Tab loadded_Tab2 in loadded_Tab1.CustomButtons_SubTab)
                                            {
                                                bool containsInTab2 = false;

                                                for (int x = 0; x < Main_Logic.main_Model?.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab.Count; x++)
                                                {
                                                    if (Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab[x].Name.Equals(loadded_Tab2.Name))
                                                    {

                                                        containsInTab2 = true;
                                                        break;
                                                    }
                                                }
                                                if (!containsInTab2)
                                                {
                                                    App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                                    {
                                                        Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab.Add(new CustomButtons_Tab() { Name = loadded_Tab2.Name });
                                                    });
                                                }
                                            }

                                            containsInTab1 = true;
                                            break;
                                        }
                                    }

                                    if (!containsInTab1)
                                    {
                                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                        {
                                            Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab.Add(new CustomButtons_Tab() { Name = loadded_Tab1.Name });

                                        });
                                        ObservableCollection<CustomButtons_Tab> subtab2 = loadded_Tab1.CustomButtons_SubTab;
                                        foreach (CustomButtons_Tab tab2 in subtab2)
                                        {
                                            App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                            {
                                                Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab.Last().CustomButtons_SubTab.Add(new CustomButtons_Tab() { Name = tab2.Name });

                                            });
                                        }

                                    }
                                }
                                containsInTab0 = true;
                                break;
                            }
                        }
                        if (!containsInTab0)
                        {
                            App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                Main_Logic.main_Model.CustomButtons_Tab_List.Add(new CustomButtons_Tab() { Name = loadded_Tab0.Name });

                            });
                            ObservableCollection<CustomButtons_Tab> subtab1 = loadded_Tab0.CustomButtons_SubTab;
                            foreach (CustomButtons_Tab tab1 in subtab1)
                            {
                                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                {
                                    Main_Logic.main_Model.CustomButtons_Tab_List.Last().CustomButtons_SubTab.Add(new CustomButtons_Tab() { Name = tab1.Name });

                                });
                                ObservableCollection<CustomButtons_Tab> subtab2 = tab1.CustomButtons_SubTab;
                                foreach (CustomButtons_Tab tab2 in subtab2)
                                {
                                    App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                    {
                                        Main_Logic.main_Model.CustomButtons_Tab_List.Last().CustomButtons_SubTab.Last().CustomButtons_SubTab.Add(new CustomButtons_Tab() { Name = tab2.Name });

                                    });
                                }

                            }

                        }
                    }

                });


                await t;
                while (t.Status != TaskStatus.RanToCompletion)
                {
                    await Task.Delay(1000);
                }
                if (t.Status == TaskStatus.RanToCompletion)
                {

                    await Task.Run(() =>
                    {

                        ObservableCollection<CustomButtons_Tab> loaded_Tabs = Main_Logic.main_Model_InitialLoad_ForAppend.CustomButtons_Tab_List;

                        foreach (CustomButtons_Tab loadded_Tab0 in loaded_Tabs)
                        {
                            for (int i = 0; i < Main_Logic.main_Model?.CustomButtons_Tab_List.Count; i++)
                            {
                                if (Main_Logic.main_Model.CustomButtons_Tab_List[i].Name.Equals(loadded_Tab0.Name))
                                {
                                    appendCustomButtonProjects_Support(loadded_Tab0, Main_Logic.main_Model.CustomButtons_Tab_List[i]);
                                    foreach (CustomButtons_Tab loadded_Tab1 in loadded_Tab0.CustomButtons_SubTab)
                                    {

                                        for (int q = 0; q < Main_Logic.main_Model?.CustomButtons_Tab_List[i].CustomButtons_SubTab.Count; q++)
                                        {
                                            if (Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].Name.Equals(loadded_Tab1.Name))
                                            {
                                                appendCustomButtonProjects_Support(loadded_Tab1, Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q]);
                                                foreach (CustomButtons_Tab loadded_Tab2 in loadded_Tab1.CustomButtons_SubTab)
                                                {

                                                    for (int x = 0; x < Main_Logic.main_Model?.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab.Count; x++)
                                                    {
                                                        if (Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab[x].Name.Equals(loadded_Tab2.Name))
                                                        {
                                                            appendCustomButtonProjects_Support(loadded_Tab2, Main_Logic.main_Model.CustomButtons_Tab_List[i].CustomButtons_SubTab[q].CustomButtons_SubTab[x]);
                                                            //containsInTab2 = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                                //containsInTab1 = true;
                                                break;
                                            }
                                        }
                                    }
                                    //containsInTab0 = true;
                                    break;

                                }
                            }
                        }
                    });
                }

            }
        }

        private static async void appendFormulaProjects()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                await Task.Run(() =>
                {
                    foreach (Formula_Project objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.Formula_Project_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.Formula_Project_List.Add(new Formula_Project(objToAppend));
                        });
                    }
                });
            }
        }


        private static async void setLoaded_MainModel(Main_Model? model)
        {

            Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Clear();
            Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Clear();
            Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Clear();

            Main_Logic.main_Model?.CustomButtons_Tab_List.Clear();
            Main_Logic.main_Model?.Formula_Project_List.Clear();
            Main_Logic.main_Model?.DataSpreadsheet_Project_List.Clear();
            if (Main_Logic.main_Model != null && model != null)
            {
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary = model.customButtons_SavedButtons_Dictionary;
                //Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary = model.customButtons_SavedButtons_IsMultiVariabble_Dictionary;
                //Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary = model.dataSpreadsheet_SavedData_Dictionary;

                await Task.Run(() =>
                {

                    foreach (CustomButtons_Tab tab0 in model.CustomButtons_Tab_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {

                            Main_Logic.main_Model.CustomButtons_Tab_List.Add(tab0);

                        });

                        foreach (CustomButtons btn in tab0.CustomButtons_List)
                        {
                            App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                if (btn.Formula_Instance.Variable_List.Count > 1)
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                }
                            });

                        }



                        foreach (CustomButtons_Tab subTab1 in tab0.CustomButtons_SubTab)
                        {
                            foreach (CustomButtons btn in subTab1.CustomButtons_List)
                            {
                                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                    if (btn.Formula_Instance.Variable_List.Count > 1)
                                    {
                                        Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                    }
                                });

                            }
                            foreach (CustomButtons_Tab subTab2 in subTab1.CustomButtons_SubTab)
                            {
                                foreach (CustomButtons btn in subTab2.CustomButtons_List)
                                {
                                    App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                    {
                                        Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                        if (btn.Formula_Instance.Variable_List.Count > 1)
                                        {
                                            Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(btn.Formula_Instance.Name, btn);
                                        }
                                    });

                                }

                            }

                        }

                    }


                    foreach (var obj in model.Formula_Project_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {

                            Main_Logic.main_Model.Formula_Project_List.Add(obj);
                        });
                    }

                    foreach (var obj in model.DataSpreadsheet_Project_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model.DataSpreadsheet_Project_List.Add(obj);
                        });
                        foreach (var spreadsheet in obj.DataSpreadsheet_List)
                        {
                            if (!string.IsNullOrWhiteSpace(spreadsheet.DataName))
                            {
                                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                {
                                    Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.Add(spreadsheet.DataName, spreadsheet);
                                });
                            }
                        }
                    }
                });
            }
        }

        private static async void setCustomButtons_andData()
        {

            await Task.Run(() =>
            {
                if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
                {
                    foreach (KeyValuePair<string, CustomButtons> objToAdd in Main_Logic.main_Model_InitialLoad_ForAppend.customButtons_SavedButtons_Dictionary)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Add(objToAdd.Key, objToAdd.Value);
                            if (objToAdd.Value.Formula_Instance.Variable_List.Count > 1)
                            {
                                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(objToAdd.Key, objToAdd.Value);
                            }
                        });

                    }

                    foreach (KeyValuePair<string, DataSpreadsheet> objToAdd in Main_Logic.main_Model_InitialLoad_ForAppend.dataSpreadsheet_SavedData_Dictionary)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Add(objToAdd.Key, objToAdd.Value);
                        });
                    }
                }
            });
        }

        private static async void loadOnly_FormulaProjects()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                Main_Logic.main_Model?.Formula_Project_List.Clear();
                await Task.Run(() =>
                {
                    foreach (Formula_Project objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.Formula_Project_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.Formula_Project_List.Add(new Formula_Project(objToAppend));
                        });
                    }
                });
            }
        }


        private static async void loadOnly_CustomButtons()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                Main_Logic.main_Model?.CustomButtons_Tab_List.Clear();
                Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Clear();
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Clear();
                await Task.Run(() =>
                {
                    foreach (CustomButtons_Tab objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.CustomButtons_Tab_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.CustomButtons_Tab_List.Add(new CustomButtons_Tab(objToAppend));
                        });
                    }




                    foreach (KeyValuePair<string, CustomButtons> objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.customButtons_SavedButtons_Dictionary)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.customButtons_SavedButtons_Dictionary.Add(objToAppend.Key, objToAppend.Value);
                            if (objToAppend.Value.Formula_Instance.Variable_List.Count > 1)
                            {
                                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(objToAppend.Key, objToAppend.Value);
                            }
                        });
                    }





                });
            }
        }


        private static async void loadOnly_DataSpreadsheetProjects()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                Main_Logic.main_Model?.DataSpreadsheet_Project_List.Clear();
                Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Clear();
                Task t = Task.Run(() =>
                {
                    foreach (DataSpreadsheet_Project objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.DataSpreadsheet_Project_List)
                    {
                        App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model?.DataSpreadsheet_Project_List.Add(new DataSpreadsheet_Project(objToAppend));
                        });
                    }
                });

                await t;
                while (t.Status != TaskStatus.RanToCompletion || t.Status == TaskStatus.WaitingForChildrenToComplete)
                {
                    await Task.Delay(1000);
                }

                await Task.Run(() =>
                {
                    if (t.Status == TaskStatus.RanToCompletion && t.Status != TaskStatus.WaitingForChildrenToComplete)
                    {
                        foreach (DataSpreadsheet_Project project in Main_Logic.main_Model_InitialLoad_ForAppend.DataSpreadsheet_Project_List)
                        {
                            foreach (DataSpreadsheet data in project.DataSpreadsheet_List)
                            {
                                if (!string.IsNullOrWhiteSpace(data.DataName))
                                {
                                    App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                    {
                                        Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Add(data.DataName, data);
                                    });
                                }
                            }
                        }
                    }
                });

            }
        }

        private static async void append_DataSpreadsheetProjects()
        {
            if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
            {
                //Main_Logic.main_Model?.DataSpreadsheet_Project_List.Clear();
                //Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Clear();
                Task t = Task.Run(() =>
                {
                    foreach (DataSpreadsheet_Project project in Main_Logic.main_Model_InitialLoad_ForAppend.DataSpreadsheet_Project_List)
                    {
                        foreach (DataSpreadsheet data in project.DataSpreadsheet_List)
                        {
                            if (Main_Logic.main_Model.dataSpreadsheet_SavedData_Dictionary.ContainsKey(data.DataName))
                            {
                                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                {
                                    project.DataSpreadsheet_List.Remove(data);
                                });
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(data.DataName))
                                {
                                    App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                                    {
                                        Main_Logic.main_Model?.dataSpreadsheet_SavedData_Dictionary.Add(data.DataName, data);
                                    });
                                }
                            }
                        }

                        //App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        //{
                        //    Main_Logic.main_Model?.DataSpreadsheet_Project_List.Add(new DataSpreadsheet_Project(project));
                        //});
                    }
                });

                await t;
                while (t.Status != TaskStatus.RanToCompletion)
                {
                    await Task.Delay(1000);
                }

                await Task.Run(() =>
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                    {
                        foreach (DataSpreadsheet_Project project in Main_Logic.main_Model_InitialLoad_ForAppend.DataSpreadsheet_Project_List)
                        {
                            App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                Main_Logic.main_Model?.DataSpreadsheet_Project_List.Add(new DataSpreadsheet_Project(project));
                            });
                            
                        }
                    }
                });
            }
        }

        //private async void appendCustomButtons()
        //{
        //    if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
        //    {
        //        await Task.Run(() =>
        //        {
        //            foreach (CustomButtons_Tab objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.customButtons_Tab_List)
        //            {
        //                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
        //                {
        //                    Main_Logic.main_Model?.customButtons_Tab_List.Add(new CustomButtons_Tab(objToAppend));
        //                });
        //            }
        //        });
        //    }
        //}

        //private async void appendDataSpreadsheetProject()
        //{
        //    if (Main_Logic.main_Model_InitialLoad_ForAppend != null)
        //    {
        //        await Task.Run(() =>
        //        {
        //            foreach (Formula_Project objToAppend in Main_Logic.main_Model_InitialLoad_ForAppend.formula_Project_List)
        //            {
        //                App._window?.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
        //                {
        //                    Main_Logic.main_Model?.Formula_Project_List.Add(new Formula_Project(objToAppend));
        //                });
        //            }
        //        });
        //    }
        //}


    }
}
