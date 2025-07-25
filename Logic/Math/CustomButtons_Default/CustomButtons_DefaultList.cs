using Perseverance_Calculator_2;
using Perseverance_Calculator_2.Logic.Xaml;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Perseverance_Calculator_2.Logic.Math.CustomButtons_Default
{
    //if (functionName.Equals("sum", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { "i" }, new List<int>() { 2 }, totalNumberOfColumns: 3, ignoreAllVar: false);
    //if (functionName.Equals("refUpdate", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { "i", "ref" }, new List<int>() { 3 }, totalNumberOfColumns: 4, ignoreAllVar: false);
    //if (functionName.Equals("atan2", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { }, new List<int>() { -1 }, totalNumberOfColumns: 2, ignoreAllVar: false);
    //if (functionName.Equals("formula", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { }, new List<int>() { 1 }, totalNumberOfColumns: 2, ignoreAllVar: true);
    //if (functionName.Equals("ifThen", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { ">", "<", ">=", "<=", "!=", "==", "true", "false", "throw" }, new List<int>() { 0, 1, 2, 3, 4 }, totalNumberOfColumns: 5, ignoreAllVar: false);
    //if (functionName.Equals("orThen", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { "true", "false", "throw" }, new List<int>() { 0, 1, 2, 3 }, totalNumberOfColumns: 4, ignoreAllVar: false);
    //if (functionName.Equals("clamp", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { }, new List<int>() { -1 }, totalNumberOfColumns: 3, ignoreAllVar: false);
    //if (functionName.Equals("random", StringComparison.CurrentCulture))
    //    return (true, new List<string>() { }, new List<int>() { -1 }, totalNumberOfColumns: 2, ignoreAllVar: false);
    public class CustomButtons_DefaultList
    {

        private static bool createDefaultTabs_Once = false;
        public static async void createDefaultTabs()
        {
            if (!createDefaultTabs_Once)
            {
                createDefaultTabs_Once = true;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Clear();
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Clear();
                Main_Logic.main_Model.CustomButtons_Tab_List.Clear();

                if (Main_Logic.main_Model.CustomButtons_Tab_List.Count > 0)
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab?.Clear();
                Main_Logic.main_Model.CustomButtons_Tab_List.Add(new CustomButtons_Tab()
                {
                    Name = "Default",
                    CustomButtons_SubTab = new ObservableCollection<CustomButtons_Tab>()
                {
                    new CustomButtons_Tab() {

                        Name="Built-In",
                        CustomButtons_SubTab= new ObservableCollection<CustomButtons_Tab>()
                        {
                            new CustomButtons_Tab() { Name="Altered" }
                        }
                    },
                    //new CustomButtons_Tab() { Name="Graph" },
                    new CustomButtons_Tab() { Name="Program" },
                    //new CustomButtons_Tab() { Name="Program" },
                }
                });

                CustomButtons_Tab tab;

                populateButtonWith_Default();
                tab = await populateButtonWith_DefaultBuiltin();

                populateButtonWith_DefaultBuiltIn_Alter(tab);
                //populateButtonWith_DefaultGraph();
                populateButtonWith_DefaultProgram();
            }
            //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab["Default"].CustomButtons_SubTab["Built-In"]
        }



        public static async Task<CustomButtons_Tab> populateButtonWith_Default()
        {
            //int indexOfDefaultTab = -1;
            bool found = false;

            if (Main_Logic.main_Model.CustomButtons_Tab_List != null)
            {
                //for (int i = 0; i < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab?.Count; i++)
                //{
                //bool breakOut = false;
                await Task.Run(() =>
                {
                    if (Main_Logic.main_Model.CustomButtons_Tab_List[0].Name.Equals("Default", StringComparison.CurrentCulture))
                    {
                        for (int j = 0; j < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Count; j++)
                        {

                            if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(
                                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List[j].Formula_Instance.Name))
                            {
                                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(
                                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List[j].Formula_Instance.Name);
                            }
                        }
                        App._window.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                        {
                            Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Clear();
                            //breakOut = true;
                            //indexOfDefaultTab = i;
                        });
                        found = true;
                        //break;
                    }
                });
                //if (breakOut) { break; }
                //}
            }
            //if (!found)
            //{
            //    CustomButtons_Tab defaultCollectionTab = new CustomButtons_Tab() { Name = "Program" };
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Add(defaultCollectionTab);
            //    indexOfDefaultTab = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.IndexOf(defaultCollectionTab);
            //}

            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            //all graphs = blue //null
            //1d graphs = green //#FF0EFF0E
            //2d graphs = orange //#FFFF6900
            //3d graphs = yellow //#FFFFEA00



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("developer"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "developer",//formula name
                        Formula_Eq = "developer(ChrisVue)",//formula
                        RearrangedFormula_BeforCalculation = "developer(ChrisVue)",//formula rearranged
                        //formula Description
                        Description = "Hello and welcome to the Perseverance Calculator 2.\r" +
                        "You'll find more information about this calculator from https://csoftwaredev.wordpress.com/ \r\r" +
                        "Info:\r\r" +
                        "1.  Most of the buttons from the default tabs cannot be replaced.  They are built into the application.\r" +
                        "2.  Most buttons from the default tab uses the C# programming language's default math functions, so if you encounter a \r" +
                        "calculation error, it's because it's how C# math works.\r" +
                        "3.  The altered tab within the default tab will contain the buttons that alters the C# default buttons.  \r" +
                        "So it will make the buttons work similarly to everyday math.\r\r" +
                        "Thank you for choosing the Perseverance Calculator.\r\r\r\r\r" +
                        "Avoid:\r\r"+
                        "1.  You must build your formulas from a project first before you can save your formulas to a file.\r"+
                        "2.  If you plan to use the buttons inside of the variable list,\r"+
                        "make sure the variable set to the button is not the same as the variables in the buttons\r"+
                        "or it will cause an infinite loop\r"+
                        "3.  'Custom' buttons can create infinite loops if you don't change the default variables\r" +
                        "when you use them (especially when creating new buttons from custom buttons).\r" +
                        "4.  Avoid extending the default tab.  That tab can be deleted and appended after" +
                        "application updates."

                        ,

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "ChrisVue",//variable name
                        "ChrisVue",//variable value
                        "Developer of the Perseverance Calculator 2"),
                    }
                    },
                    use: "developer(ChrisVue)",//formula formula use
                    isMultiVarFunction: false
                    ////variable Description
                    ));


                //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<string>() { };
                //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<int>() { 1 };
                //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                //Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last().Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_List[index]);
            }
            return Main_Logic.main_Model.CustomButtons_Tab_List[0];

        }



        public static async Task<CustomButtons_Tab> populateButtonWith_DefaultBuiltIn_Alter(CustomButtons_Tab subTab)
        {
            int indexOfDefaultTab = -1;
            bool found = false;

            if (subTab != null)
            {
                for (int i = 0; i < subTab.CustomButtons_SubTab?.Count; i++)
                {
                    bool breakOut = false;
                    await Task.Run(() =>
                    {
                        if (subTab.CustomButtons_SubTab[i].Name.Equals("Altered", StringComparison.CurrentCulture))
                        {
                            for (int j = 0; j < subTab.CustomButtons_SubTab[i].CustomButtons_List.Count; j++)
                            {

                                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(
                                    subTab.CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name))
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(
                                        subTab.CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name);
                                }
                            }
                            App._window.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                subTab.CustomButtons_SubTab[i].CustomButtons_List.Clear();
                                breakOut = true;
                                indexOfDefaultTab = i;
                            });
                            found = true;
                            //break;
                        }
                    });
                    if (breakOut) { break; }
                }
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("sinx"))
            {
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "sinx",//formula name
                        Formula_Eq =
                        "formula(sin2π,ifThen(x%(2*π),==,0,0,sin(x)))" +
                        "formula(sin360,ifThen(x%360,==,0,0,sin((x)*(π/180))))" +
                        "formula(calc,ifThen(isXRadian,==,true,sin2π,sin360))\r" +

                        "calc",//formula
                        RearrangedFormula_BeforCalculation =
                        "formula(sin2π,ifThen(x%(2*π),==,0,0,sin(x)))" +
                        "formula(sin360,ifThen(x%360,==,0,0,sin((x)*(π/180))))" +
                        "formula(calc,ifThen(isXRadian,==,true,sin2π,sin360))\r" +

                        "calc",//formula rearranged
                        Description = "Altered version of built-in sin.",//formula Description

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "a number or expression"),

                        new Variable(
                        //"x",//variable
                        "isXRadian",//variable name
                        "isXRadian",//variable value
                        "Is x in radian? (true false)"),
                        },
                    },
                    use: "sinx(x,isXRadian)",//formula formula use
                    isMultiVarFunction: true
                    ////variable Description
                    ));


                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val=-1 } };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("cosx"))
            {
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "cosx",//formula name
                        Formula_Eq =

                        "formula(cosπ2,ifThen(abs(x)%(π/2),==,0,0,cos(x)))" +
                        "formula(cos3π2,ifThen(abs(x)%(3*π/2),==,0,0,cosπ2))" +

                        "formula(cos360_90,ifThen(abs(x)%90,==,0,0,cos((x)*(π/180))))" +
                        "formula(cos360_270,ifThen(abs(x)%270,==,0,0,cos360_90))" +

                        "formula(xNot360deg180,ifThen(abs(x)%180,==,0,cos((x)*(π/180)),cos360_270))" +
                        "formula(xNot360rad180,ifThen(abs(x)%(π),==,0,cos(x),cos3π2))" +

                        "formula(calc,ifThen(isXRadian,==,true,xNot360rad180,xNot360deg180))\r" +
                        //"formula(calc,ifThen(isXRadian,==,true,cosπ2,cos360_90))\r" +

                        "calc",//formula
                        RearrangedFormula_BeforCalculation =


                        "formula(cosπ2,ifThen(abs(x)%(π/2),==,0,0,cos(x)))" +
                        "formula(cos3π2,ifThen(abs(x)%(3*π/2),==,0,0,cosπ2))" +

                        "formula(cos360_90,ifThen(abs(x)%90,==,0,0,cos((x)*(π/180))))" +
                        "formula(cos360_270,ifThen(abs(x)%270,==,0,0,cos360_90))" +

                        "formula(xNot360deg180,ifThen(abs(x)%180,==,0,cos((x)*(π/180)),cos360_270))" +
                        "formula(xNot360rad180,ifThen(abs(x)%(π),==,0,cos(x),cos3π2))" +

                        "formula(calc,ifThen(isXRadian,==,true,xNot360rad180,xNot360deg180))\r" +
                        //"formula(calc,ifThen(isXRadian,==,true,cosπ2,cos360_90))\r" +

                        "calc",//formula rearranged
                        Description = "Altered version of built-in cos.",//formula Description

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "a number or expression"),

                        new Variable(
                        //"x",//variable
                        "isXRadian",//variable name
                        "isXRadian",//variable value
                        "Is x in radian? (true false)"),
                        },
                    },
                    use: "cosx(x,isXRadian)",//formula formula use
                    isMultiVarFunction: true
                    ////variable Description
                    ));


                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("tanx"))
            {
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "tanx",//formula name
                        Formula_Eq = "formula(asymRad,((x)/(π/2))%2)\r" +
                        "formula(isPos1Rad,ifThen(asymRad,==,1,true,false))\r" +
                        "formula(isNeg1Rad,ifThen(asymRad,==,-1,true,false))\r" +
                        "formula(calcRad,orThen(isPos1Rad,isNeg1Rad,throw_IsAsymptote,tan(x)))\r" +

                        "formula(asymDec,(((x)*(π/180))/(π/2))%2)\r" +
                        "formula(isPos1Dec,ifThen(asymDec,==,1,true,false))\r" +
                        "formula(isNeg1Dec,ifThen(asymDec,==,-1,true,false))\r" +
                        "formula(calcDec,orThen(isPos1Dec,isNeg1Dec,throw_IsAsymptote,tan((x)*π/180)))\r" +


                        "formula(calc,ifThen(isXRadian,==,true,calcRad,calcDec))\r" +

                        "calc",//formula
                        RearrangedFormula_BeforCalculation = "formula(asymRad,((x)/(π/2))%2)\r" +
                        "formula(isPos1,ifThen(asymRad,==,1,true,false))\r" +
                        "formula(isNeg1,ifThen(asymRad,==,-1,true,false))\r" +
                        "formula(calcRad,orThen(isPos1,isNeg1,throw_IsAsymptote,tan(x)))\r" +

                        "formula(asymDec,(((x)*(π/180))/(π/2))%2)\r" +
                        "formula(isPos1Dec,ifThen(asymDec,==,1,true,false))\r" +
                        "formula(isNeg1Dec,ifThen(asymDec,==,-1,true,false))\r" +
                        "formula(calcDec,orThen(isPos1Dec,isNeg1Dec,throw_IsAsymptote,tan((x)*π/180)))\r" +


                        "formula(calc,ifThen(isXRadian,==,true,calcRad,calcDec))\r" +

                        "calc",//formula rearranged
                        Description = "Altered version of built-in tan.",//formula Description

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "a number or expression"),

                        new Variable(
                        //"x",//variable
                        "isXRadian",//variable name
                        "isXRadian",//variable value
                        "Is x in radian? (true false)"),
                        },
                    },
                    use: "tanx(x,isXRadian)",//formula formula use
                    isMultiVarFunction: true
                    ////variable Description
                    ));


                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    subTab.CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }

            return subTab.CustomButtons_SubTab[indexOfDefaultTab];
        }




        public static async Task<CustomButtons_Tab> populateButtonWith_DefaultProgram()
        {
            int indexOfDefaultTab = -1;
            bool found = false;

            if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab != null)
            {
                for (int i = 0; i < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab?.Count; i++)
                {
                    bool breakOut = false;
                    await Task.Run(() =>
                    {
                        if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].Name.Equals("Program", StringComparison.CurrentCulture))
                        {
                            for (int j = 0; j < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Count; j++)
                            {

                                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(
                                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name))
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(
                                        Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name);
                                }
                            }
                            App._window.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Clear();
                                breakOut = true;
                                indexOfDefaultTab = i;
                            });
                            found = true;
                            //break;
                        }
                    });
                    if (breakOut) { break; }
                }
            }
            //if (!found)
            //{
            //    CustomButtons_Tab defaultCollectionTab = new CustomButtons_Tab() { Name = "Program" };
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Add(defaultCollectionTab);
            //    indexOfDefaultTab = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.IndexOf(defaultCollectionTab);
            //}

            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            //all graphs = blue //null
            //1d graphs = green //#FF0EFF0E
            //2d graphs = orange //#FFFF6900
            //3d graphs = yellow //#FFFFEA00



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("formula"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "formula",//formula name
                        Formula_Eq = "formula(Name,x)",//formula
                        RearrangedFormula_BeforCalculation = "formula(Name,x)",//formula rearranged
                        Description = "Acts as a variable for an expression.  This will replace all 'Name' with the expression 'x' before calculations.\r 'x'is solved only during calculating.",//formula Description

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "Name",//variable name
                        "Name",//variable value
                        "name of formula"),
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "formula expression")},
                    },
                    use: "formula(Name,x)",//formula formula use
                    isMultiVarFunction: true
                    ////variable Description
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }










            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("var"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(
                    new Formula()
                    {
                        Name = "var",//formula name
                        Formula_Eq = "var(Name,x)",//formula
                        RearrangedFormula_BeforCalculation = "var(Name,x)",//formula rearranged
                        Description = "This formula creates a variable.  It will replace all 'Name' with the expression 'x' before calculations.\r 'x'is solved before calculating.",//formula Description

                        Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "Name",//variable name
                        "Name",//variable value
                        "name of variable"),
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "variable expression")},
                    },
                    use: "var(Name,x)",//formula formula use
                    isMultiVarFunction: true
                    ////variable Description
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val="Name" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 0 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }







            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("refUpdate"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "refUpdate",//formula name
                    Formula_Eq = "refUpdate(i,n,ref,x)",//formula
                    RearrangedFormula_BeforCalculation = "refUpdate(i,n,ref,x)",//formula rearranged
                    Description = "Loop from i to n while updating ref by x.  The variable ref must be included in the expression x\r" +
                    "Example: refUpdate(0,10,1,ref + i + 1)\r\r" +
                    "Programming example:\r\r" +
                    "double ref = 1;\r" +
                    "for(int i = 0; i<=10;i++)\r" +
                    "     ref+=i + 1;",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "i",//variable name
                        "i",//variable value
                        "startIndex; lower than n"),
                        new Variable(
                        //"x",//variable
                        "n",//variable name
                        "n",//variable value
                        "endIndex; greater than or equal to n"),
                        new Variable(
                        //"x",//variable
                        "ref",//variable name
                        "ref",//variable value
                        "the initial value to be updated"),
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "formula expression; must include ref; can include i"),

                    },
                },
                    use: "refUpdate(i,n,ref,x)",//formula formula use
                    isMultiVarFunction: true

                    ////variable Description
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val="i" }, new StringBinding() { Val = "ref" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 3 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 4;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;

                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }









            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("ifThen"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "ifThen",//formula name
                    Formula_Eq = "ifThen(x,rOperator,y,trueReturn,falseReturn)",//formula
                    RearrangedFormula_BeforCalculation = "ifThen(x,rOperator,y,trueReturn,falseReturn)",//formula rearranged
                    Description = "If x compared to y is true then return a value (trueReturn) else false then return a value (falseReturn); ",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "The first expression; can be an expression, 'true' or 'false'"),
                        new Variable(
                        //"x",//variable
                        "rOperator",//variable name
                        "rOperator",//variable value
                        "Relational Operator (>,<,>=,<=,!=,==); For true and false comparison use either (==, or !=)"),//variable Description,
                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "The second expression: can be an expression, 'true' or 'false'"),//variable Description,
                        new Variable(
                        //"x",//variable
                        "trueReturn",//variable name
                        "trueReturn",//variable value
                        "Can set this as a new expression to be calculated, or set this as 'true' or 'false' to be compared again within another another function that accepts true or false. " +
                        "Can set this as 'throw' followed by an error message to cause an error."),//variable Description,
                        new Variable(
                        //"x",//variable
                        "falseReturn",//variable name
                        "falseReturn",//variable value
                        "Can set this as a new expression to be calculated, or set this as 'true' or 'false' to be compared again within another another function that accepts true or false. "+
                        "Can set this as 'throw' followed by an error message to cause an error. (throw_Error)"),//variable Description

                    },
                },
                    use: "ifThen(x,rOperator,y,trueReturn,falseReturn)",//formula formula use
                    isMultiVarFunction: true


                    //
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val = ">" }, new StringBinding() { Val = "<" }, new StringBinding() { Val = ">=" }, new StringBinding() { Val = "<=" }, new StringBinding() { Val = "!=" }, new StringBinding() { Val = "==" }, new StringBinding() { Val = "true" }, new StringBinding() { Val="false" }, new StringBinding() { Val = "throw" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 0 }, new IntBinding() { Val = 1 }, new IntBinding() { Val = 2 }, new IntBinding() { Val = 3 }, new IntBinding() { Val = 4 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 5;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }





            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("ifThen2"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "ifThen2",//formula name
                    Formula_Eq = "ifThen2(x,rOperator,y,trueReturn,falseReturn)",//formula
                    RearrangedFormula_BeforCalculation = "ifThen2(x,rOperator,y,trueReturn,falseReturn)",//formula rearranged
                    Description = "If x compared to y is true then return a value (trueReturn) else false then return a value (falseReturn); ",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "The first expression; can be an expression or a word"),
                        new Variable(
                        //"x",//variable
                        "rOperator",//variable name
                        "rOperator",//variable value
                        "Relational Operator (>,<,>=,<=,!=,==); For true and false comparison use either (==, or !=)\r" +
                        "words can only be compared with == or !="),//variable Description,
                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "The second expression: can be an expression or a word"),//variable Description,
                        new Variable(
                        //"x",//variable
                        "trueReturn",//variable name
                        "trueReturn",//variable value
                        "Can set this as a new expression to be calculated, or set this as 'true' \r" +
                        "or 'false' to be compared again within another another function that accepts true or false. " +
                        "Can set this as 'throw' followed by an error message to cause an error."),//variable Description,
                        new Variable(
                        //"x",//variable
                        "falseReturn",//variable name
                        "falseReturn",//variable value
                        "Can set this as a new expression to be calculated, or set this as 'true' \r" +
                        "or 'false' to be compared again within another another function that accepts true or false. "+
                        "Can set this as 'throw' followed by an error message to cause an error. (throw_Error)"),//variable Description

                    },
                },
                    use: "ifThen2(x,rOperator,y,trueReturn,falseReturn)",//formula formula use
                    isMultiVarFunction: true


                    //
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val = ">" }, new StringBinding() { Val = "<" }, new StringBinding() { Val = ">=" }, new StringBinding() { Val = "<=" }, new StringBinding() { Val = "!=" }, new StringBinding() { Val = "==" }, new StringBinding() { Val = "true" }, new StringBinding() { Val = "false" }, new StringBinding() { Val = "throw" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 0 }, new IntBinding() { Val = 1 }, new IntBinding() { Val = 2 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 5;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ParamValCanBeSet_DuringCalc = true;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("orThen"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "orThen",//formula name
                    Formula_Eq = "orThen(x,y,trueReturn,falseReturn)",//formula
                    RearrangedFormula_BeforCalculation = "orThen(x,y,trueReturn,falseReturn)",//formula rearranged
                    Description = "If x is true or y is true then return a value (trueReturn) else false then return a value (falseReturn)",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "The first expression; can 'true' or 'false'; can use ifThen to return true or false;"),
                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "The second expression: can 'true' or 'false'; can use ifThen to return true or false;"),//variable Description,,
                        new Variable(
                        //"x",//variable
                        "trueReturn",//variable name
                        "trueReturn",//variable value
                        "Can set this as a ,new expression to be calculated, or set this as 'true' or 'false' to be compared again within another function that accepts true or false. "+
                        "Can set this as 'throw' followed by an error message to cause an error."),//variable Description

                        new Variable(
                        //"x",//variable
                        "falseReturn",//variable name
                        "falseReturn",//variable value
                        "Can set this as a new expression to be calculated, or set this as 'true' or 'false' to be compared again within another function that accepts true or false. " +
                        "Can set this as 'throw' followed by an error message to cause an error."),//variable Description
                    },
                },
                    use: "orThen(x,y,trueReturn,falseReturn)",//formula formula use
                    isMultiVarFunction: true


                    //functionTab_IndexLocation: 
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val = "true" }, new StringBinding() { Val = "false" }, new StringBinding() { Val = "throw" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 0 }, new IntBinding() { Val = 1 }, new IntBinding() { Val = 2 }, new IntBinding() { Val = 3 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 4;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }





            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("trim"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "trim",//formula name
                    Formula_Eq = "trim(x,y,isRounded)",//formula
                    RearrangedFormula_BeforCalculation = "trim(x,y,isRounded)",//formula rearranged
                    Description = "Trim a number (x) based on the decimal place.",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is the number to be trimmed"),//variable Description

                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "y is an integer and represents the decimal place (can be negative for integer)"),//variable Description

                        new Variable(
                        //"x",//variable
                        "isRounded",//variable name
                        "isRounded",//variable value
                        "isRounded is true or false"),//variable Description
                    },
                },
                    use: "trim(x,y,isRounded)",//formula formula use
                    isMultiVarFunction: true


                    //functionTab_IndexLocation: 
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val = "true" }, new StringBinding() { Val = "false" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 2 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 3;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ParamValCanBeSet_DuringCalc = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }





            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("count"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "count",//formula name
                    Formula_Eq = "count(x)",//formula
                    RearrangedFormula_BeforCalculation = "count(x)",//formula rearranged
                    Description = "returns the length of a decimal number (including the decimal and negative)",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is a number"),//variable Description
                    },
                },
                    use: "count(x)",//formula formula use
                    isMultiVarFunction: false


                    //functionTab_IndexLocation: 
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 1;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                //Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("count2"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "count2",//formula name
                    Formula_Eq = "count2(x)",//formula
                    RearrangedFormula_BeforCalculation = "count2(x)",//formula rearranged
                    Description = "returns the length of a decimal number (excluding the decimal and negative)",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is a number"),//variable Description
                    },
                },
                    use: "count2(x)",//formula formula use
                    isMultiVarFunction: false


                    //functionTab_IndexLocation: 
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() {};
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 1;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                //Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("dPlace"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "dPlace",//formula name
                    Formula_Eq = "dPlace(x)",//formula
                    RearrangedFormula_BeforCalculation = "dPlace(x)",//formula rearranged
                    Description = "Returns the number of decimal places.",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "A decimal number or expression"),
                    },
                },
                    use: "dPlace(x)"//formula formula use


                    //functionTab_IndexLocation: 
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("isnumber"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "isnumber",//formula name
                    Formula_Eq = "isnumber(x)",//formula
                    RearrangedFormula_BeforCalculation = "isnumber(x)",//formula rearranged
                    Description = "Returns true if the solution of x is a number, otherwise returns false.",//formula Description
                    Variable_List = new ObservableCollection<Variable> {

                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "can be anything"),
                    },
                },
                    use: "isnumber(x)"//formula formula use
                    

                    //functionTab_IndexLocation: 
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val = "true" }, new StringBinding() { Val = "false" }, new StringBinding() { Val = "throw" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 0 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 1;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ParamValCanBeSet_DuringCalc = true;

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            //-------------------------3D Graph
            //-------------------------3D Graph
            //-------------------------3D Graph
            //-------------------------3D Graph



            //TESTING

            //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
            //    new Model.Formula.CustomButtons(
            //        "timex",//formula name
            //        "timex(x,y)",//formula
            //        "timex(x,y)",//formula rearranged
            //        "timex(x,y)",//formula formula use
            //        "test",//formula Description
            //        new ObservableCollection<Variable>
            //        {
            //            new Variable(
            //            //"x",//variable
            //            "x",//variable name
            //            "x",//variable value
            //            ""),
            //            new Variable(
            //            //"x",//variable
            //            "y",//variable name
            //            "y",//variable value
            //            "")
            //        },//variable Description
            //        ignoreFunctionForGraph: true
            //        ));
            //index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
            //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);




            return Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab];

        }





        public static async Task<CustomButtons_Tab> populateButtonWith_DefaultGraph()
        {
            int indexOfDefaultTab = -1;
            bool found = false;

            if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab != null)
            {
                for (int i = 0; i < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Count; i++)
                {
                    bool breakOut = false;
                    await Task.Run(() =>
                    {
                        if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].Name.Equals("Graph", StringComparison.CurrentCulture))
                        {
                            for (int j = 0; j < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Count; j++)
                            {
                                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(
                                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name))
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(
                                        Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name);
                                }
                            }
                            App._window.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Clear();
                                breakOut = true;
                                indexOfDefaultTab = i;
                            });
                            found = true;
                            //break;
                        }
                    });
                    if (breakOut) { break; }
                }
            }
            //if (!found)
            //{
            //    CustomButtons_Tab defaultCollectionTab = new CustomButtons_Tab() { Name = "Graph" };
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Add(defaultCollectionTab);
            //    indexOfDefaultTab = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.IndexOf(defaultCollectionTab);
            //}

            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            ////-------------------------Constants
            //all graphs = blue //null
            //1d graphs = green //#FF0EFF0E
            //2d graphs = orange //#FFFF6900
            //3d graphs = yellow //#FFFFEA00
            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("time"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                    new Model.Formula.CustomButtons(new Formula()
                    {
                        Name = "time",//formula name
                        Formula_Eq = "time",//formula
                        RearrangedFormula_BeforCalculation = "time",//formula rearranged
                        Description = "The time it takes to update the graph.  Time is used along with the play button in graphs.",//formula Description
                        Variable_List = new ObservableCollection<Variable>
                        {
                        },
                    },
                    "time"//formula formula use


                        ////variable Description
                        ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }







            //-------------------------1D Graph
            //-------------------------1D Graph
            //-------------------------1D Graph
            //-------------------------1D Graph



            //-------------------------2D Graph
            //-------------------------2D Graph
            //-------------------------2D Graph
            //-------------------------2D Graph


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("circleRadius"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "circleRadius",//formula name
                    Formula_Eq = "circleRadius",//formula
                    RearrangedFormula_BeforCalculation = "circleRadius",//formula rearranged
                    Description = "circleRadius - Works only with 2D Graph; Returns the radius of a point plotted in 2d Graph.  It can be altered in the graphs' add section",//formula Description

                    Variable_List = new ObservableCollection<Variable>
                    {
                    },
                },
                use: "circleRadius"

                    /*,*/
                    //////////////////////////////////////////////////////////////////////////////"circleRadius",//formula formula use

                    ////variable Description
                    //ignoreFunctionForGraph: false,
                    ////////////////////////////////////////////////////////////////////////////"#FFFF6900"
                    /*,*/
                    //new SolidColorBrush(Windows.UI.Color.FromArgb(
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).A,//orange
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).R,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).G,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).B

                    //    ))//hex is orange
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("vec2"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "vec2",//formula name
                    Formula_Eq = "vec2(x,y)",//formula
                    RearrangedFormula_BeforCalculation = "vec2(x,y)",//formula rearranged
                    Description = "2d vector - only works with 2D graph; can only be used by itself but only once.  It plots a point on the graph.",//formula Description
                    Variable_List = new ObservableCollection<Variable>
                    {
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x position"),
                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "y position")
                    },
                },
                    use: "vec2(x,y)"/*,*///formula formula use

                    ////variable Description
                    //ignoreFunctionForGraph: true,
                    //"#FFFF6900"
                    /*,*/
                    //new SolidColorBrush(Windows.UI.Color.FromArgb(
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).A,//orange
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).R,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).G,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).B

                    //    ))//hex is orange
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("instance"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "instance",//formula name
                    Formula_Eq = "instance(x,y)",//formula
                    RearrangedFormula_BeforCalculation = "instance(x,y)",//formula rearranged
                    Description = "instance - only works with 2D graph; can only be used within vec2; " +
                    "'x' and 'y' must be the same value when using 'instance' multiple times in vec2 " +
                    "creates a copy of an expression starting from x to y; " +
                    "at the same time 'instance' will return the number of the current instance",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable>
                    {
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x starting instance (integer)"),
                        new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "y ending instance (integer greater than x)")
                    },
                },
                    use: "instance(x,y)",//formula formula use
                    isMultiVarFunction: true

                    //variable Description
                    //ignoreFunctionForGraph: true,
                    //"#FFFF6900"
                    /*,*/
                    //new SolidColorBrush(Windows.UI.Color.FromArgb(
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).A,//orange
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).R,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).G,
                    //    ((System.Drawing.Color)new ColorConverter().ConvertFromString("#FFFF6900")).B

                    //    ))//hex is orange
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;

                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            //-------------------------3D Graph
            //-------------------------3D Graph
            //-------------------------3D Graph
            //-------------------------3D Graph



            //TESTING

            //Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
            //    new Model.Formula.CustomButtons(
            //        "timex",//formula name
            //        "timex(x,y)",//formula
            //        "timex(x,y)",//formula rearranged
            //        "timex(x,y)",//formula formula use
            //        "test",//formula Description
            //        new ObservableCollection<Variable>
            //        {
            //            new Variable(
            //            //"x",//variable
            //            "x",//variable name
            //            "x",//variable value
            //            ""),
            //            new Variable(
            //            //"x",//variable
            //            "y",//variable name
            //            "y",//variable value
            //            "")
            //        },//variable Description
            //        ignoreFunctionForGraph: true
            //        ));
            //index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
            //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);



            return Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab];


        }




















































        public static async Task<CustomButtons_Tab> populateButtonWith_DefaultBuiltin()
        {
            int indexOfDefaultTab = -1;
            bool found = false;

            if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab != null)
            {
                for (int i = 0; i < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Count; i++)
                {
                    bool breakOut = false;
                    await Task.Run(() =>
                    {
                        if (Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].Name.Equals("Built-In", StringComparison.CurrentCulture))
                        {
                            for (int j = 0; j < Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Count; j++)
                            {
                                if (Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey(
                                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name))
                                {
                                    Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Remove(
                                        Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List[j].Formula_Instance.Name);
                                }
                            }
                            App._window.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                            {
                                breakOut = true;
                                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[i].CustomButtons_List.Clear();
                            });
                            indexOfDefaultTab = i;
                            found = true;
                            indexOfDefaultTab = i;
                            //break;
                        }
                    });
                    if (breakOut) break;
                }
            }
            //if (!found)
            //{
            //    CustomButtons_Tab defaultCollectionTab = new CustomButtons_Tab() { Name = "Default" };
            //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.Add(defaultCollectionTab);
            //    indexOfDefaultTab = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab.IndexOf(defaultCollectionTab);
            //}







            //-------------------------Constants
            //-------------------------Constants
            //-------------------------Constants
            //-------------------------Constants

            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("π"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "π",//formula name
                    Formula_Eq = System.Math.PI.ToString(),//formula
                    RearrangedFormula_BeforCalculation = System.Math.PI.ToString(),//formula rearranged
                    Description = "Constant PI",//formula Description
                    Variable_List = new ObservableCollection<Variable>
                    {
                    },
                },
                    "π"//formula formula use
                       //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("e"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "e",//formula name
                    Formula_Eq = System.Math.E.ToString(),//formula
                    RearrangedFormula_BeforCalculation = System.Math.E.ToString(),//formula rearranged
                    Description = "Constant e",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable>
                    {
                    },
                },



                    "e"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("unitcon"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "unitcon",//formula name
                    Formula_Eq =

                    //============================From
                    "formula(giga_,ifThen2(from,==,giga,(10^9),mega_))\r" +
                    "formula(mega_,ifThen2(from,==,mega,(10^6),kilo_))\r" +
                    "formula(kilo_,ifThen2(from,==,kilo,(10^3),deci_))\r" +

                    "formula(deci_,ifThen2(from,==,deci,(10^(-1)),centi_))\r" +
                    "formula(centi_,ifThen2(from,==,centi,(10^(-2)),milli_))\r" +
                    "formula(milli_,ifThen2(from,==,milli,(10^(-3)),micro_))\r" +
                    "formula(micro_,ifThen2(from,==,micro,(10^(-6)),nano_))\r" +
                    "formula(nano_,ifThen2(from,==,nano,(10^(-9)),pico_))\r" +
                    "formula(pico_,ifThen2(from,==,pico,(10^(-12)),foot_))\r" +

                    "formula(foot_,ifThen2(from,==,foot,(3.28084),yard_))\r" +
                    "formula(yard_,ifThen2(from,==,yard,(1.09361),mile_))\r" +
                    "formula(mile_,ifThen2(from,==,mile,(0.000621),inch_))\r" +
                    //"formula(inch_,ifThen2(from,==,inch,(39.3701),false))\r" +
                    "formula(inch_,ifThen2(from,==,inch,(39.37008),false))\r" +

                    "formula(base_,ifThen2(from,==,base,(1),giga_))\r\r" +

                    //==============================To

                    "formula(gigaTo_,ifThen2(to,==,giga,(10^9),megaTo_))\r" +
                    "formula(megaTo_,ifThen2(to,==,mega,(10^6),kiloTo_))\r" +
                    "formula(kiloTo_,ifThen2(to,==,kilo,(10^3),deciTo_))\r" +

                    "formula(deciTo_,ifThen2(to,==,deci,(10^(-1)),centiTo_))\r" +
                    "formula(centiTo_,ifThen2(to,==,centi,(10^(-2)),milliTo_))\r" +
                    "formula(milliTo_,ifThen2(to,==,milli,(10^(-3)),microTo_))\r" +
                    "formula(microTo_,ifThen2(to,==,micro,(10^(-6)),nanoTo_))\r" +
                    "formula(nanoTo_,ifThen2(to,==,nano,(10^(-9)),picoTo_))\r" +
                    "formula(picoTo_,ifThen2(to,==,pico,(10^(-12)),footTo_))\r" +

                    "formula(footTo_,ifThen2(to,==,foot,(3.28084),yardTo_))\r" +
                    "formula(yardTo_,ifThen2(to,==,yard,(1.09361),mileTo_))\r" +
                    "formula(mileTo_,ifThen2(to,==,mile,(0.000621),inchTo_))\r" +
                    //"formula(inchTo_,ifThen2(to,==,inch,(39.3701),false))\r" +
                    "formula(inchTo_,ifThen2(to,==,inch,(39.37008),false))\r" +

                    "formula(baseTo_,ifThen2(to,==,base,(1),gigaTo_))\r\r" +

                    //"formula(calcBase,ifThen2(base_,>,1,(x)/(base_),(1/(base_)) ))\r" +
                    //"formula(calcBaseTo,ifThen2(baseTo_,>,1,(x)/(baseTo_),(1/(baseTo_)) ))\r" +


                    "formula(calc,(x)*(base_)*1/(baseTo_))\r\r" +
                    "calc"


                    ,//formula
                    RearrangedFormula_BeforCalculation =

                    //============================From
                    "formula(giga_,ifThen2(from,==,giga,(10^9),mega_))\r" +
                    "formula(mega_,ifThen2(from,==,mega,(10^6),kilo_))\r" +
                    "formula(kilo_,ifThen2(from,==,kilo,(10^3),deci_))\r" +

                    "formula(deci_,ifThen2(from,==,deci,(10^(-1)),centi_))\r" +
                    "formula(centi_,ifThen2(from,==,centi,(10^(-2)),milli_))\r" +
                    "formula(milli_,ifThen2(from,==,milli,(10^(-3)),micro_))\r" +
                    "formula(micro_,ifThen2(from,==,micro,(10^(-6)),nano_))\r" +
                    "formula(nano_,ifThen2(from,==,nano,(10^(-9)),pico_))\r" +
                    "formula(pico_,ifThen2(from,==,pico,(10^(-12)),foot_))\r" +

                    "formula(foot_,ifThen2(from,==,foot,(3.28084),yard_))\r" +
                    "formula(yard_,ifThen2(from,==,yard,(1.09361),mile_))\r" +
                    "formula(mile_,ifThen2(from,==,mile,(0.000621),inch_))\r" +
                    //"formula(inch_,ifThen2(from,==,inch,(39.3701),false))\r" +
                    "formula(inch_,ifThen2(from,==,inch,(39.37008),false))\r" +

                    "formula(base_,ifThen2(from,==,base,(1),giga_))\r\r" +

                    //==============================To

                    "formula(gigaTo_,ifThen2(to,==,giga,(10^9),megaTo_))\r" +
                    "formula(megaTo_,ifThen2(to,==,mega,(10^6),kiloTo_))\r" +
                    "formula(kiloTo_,ifThen2(to,==,kilo,(10^3),deciTo_))\r" +

                    "formula(deciTo_,ifThen2(to,==,deci,(10^(-1)),centiTo_))\r" +
                    "formula(centiTo_,ifThen2(to,==,centi,(10^(-2)),milliTo_))\r" +
                    "formula(milliTo_,ifThen2(to,==,milli,(10^(-3)),microTo_))\r" +
                    "formula(microTo_,ifThen2(to,==,micro,(10^(-6)),nanoTo_))\r" +
                    "formula(nanoTo_,ifThen2(to,==,nano,(10^(-9)),picoTo_))\r" +
                    "formula(picoTo_,ifThen2(to,==,pico,(10^(-12)),footTo_))\r" +

                    "formula(footTo_,ifThen2(to,==,foot,(3.28084),yardTo_))\r" +
                    "formula(yardTo_,ifThen2(to,==,yard,(1.09361),mileTo_))\r" +
                    "formula(mileTo_,ifThen2(to,==,mile,(0.000621),inchTo_))\r" +
                    //"formula(inchTo_,ifThen2(to,==,inch,(39.3701),false))\r" +
                    "formula(inchTo_,ifThen2(to,==,inch,(39.37008),false))\r" +

                    "formula(baseTo_,ifThen2(to,==,base,(1),gigaTo_))\r\r" +

                    //"formula(calcBase,ifThen2(base_,>,1,(x)/(base_),(1/(base_)) ))\r" +
                    //"formula(calcBaseTo,ifThen2(baseTo_,>,1,(x)/(baseTo_),(1/(baseTo_)) ))\r" +


                    "formula(calc,(x)*(base_)*1/(baseTo_))\r\r" +
                    "calc"

,//formula rearranged
                    Description = "Unit conversion: convert from one unit of measurement to the next.",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable>
                    {
                        new Variable(
                            name:"x",
                            varValue:"x",
                            description:"An Expression or the default unit value."
                            ),
                        new Variable(
                            name:"from",
                            varValue:"from",
                            description:"a unit of measurement\r" +
                            "giga,mega,kilo,base,deci,centi,mili,micro,nano,pico\r"+
                            "foot, yard, mile, inch"
                            ),
                        new Variable(
                            name:"to",
                            varValue:"to",
                            description:"a unit of measurement\r" +
                            "giga,mega,kilo,base,deci,centi,mili,micro,nano,pico\r"+
                            "foot, yard, mile, inch"
                            )
                    },
                },

                //TODO:

                    use:"unitcon(x,from,to)",//formula formula use
                    isMultiVarFunction:true
                    //variable Description
                    ));


                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 1 }, new IntBinding() { Val = 2 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 3;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ParamValCanBeSet_DuringCalc = true;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("random"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "random",//formula name
                    Formula_Eq = "random(min,max)",//formula
                    RearrangedFormula_BeforCalculation = "random(min,max)",//formula rearranged
                    Description = "Generate a random number >= min and < y; Includes min; Not including max",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "min",//variable name
                        "min",//variable value
                        "min is an expression; Integer;"),new Variable(
                        //"x",//variable
                        "max",//variable name
                        "max",//variable value
                        "max is an expression; Integer;"),

                    },
                },
                    "random(min,max)",//formula formula use
                    isMultiVarFunction: true

                    //variable Description
                    ));



                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>();
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("sqrt"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "sqrt",//formula name
                    Formula_Eq = "sqrt(x)",//formula
                    RearrangedFormula_BeforCalculation = "sqrt(x)",//formula rearranged
                    Description = "square root of a number",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is a number")},
                },



                    "sqrt(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("pow"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "pow",//formula name
                    Formula_Eq = "pow(x,y)",//formula
                    RearrangedFormula_BeforCalculation = "pow(x,y)",//formula rearranged
                    Description = "power of a number (x) raised to the number (y)",//formula Description
                    Variable_List = new ObservableCollection<Variable> {
                    new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is the number"),
                    new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "y is the power")},
                },


                    isMultiVarFunction: true,
                    use: "pow(x,y)"//formula formula use


                    //variable Description
                    ));



                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());




                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }

            //-----------------ATan2
            //-----------------ATan2
            //-----------------ATan2
            //-----------------ATan2


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("atan2"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "atan2",//formula name
                    Formula_Eq = "atan2(x,y)",//formula
                    RearrangedFormula_BeforCalculation = "atan2(x,y)",//formula rearranged
                    Description = "Select a point (x,y) on a circle and returns the degree.  0 degree starts at 90 degrees",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x"),
                    new Variable(
                        //"x",//variable
                        "y",//variable name
                        "y",//variable value
                        "y")
                    },
                },



                    "atan2(x,y)",//formula formula use
                    isMultiVarFunction: true

                    //variable Description
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = false;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 2;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());


                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }





            //-----------------SINCOSTAN
            //-----------------SINCOSTAN
            //-----------------SINCOSTAN
            //-----------------SINCOSTAN


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("sin"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "sin",//formula name
                    Formula_Eq = "sin(x)",//formula
                    RearrangedFormula_BeforCalculation = "sin(x)",//formula rearranged
                    Description = "sin of an angle",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "sin(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("cos"))
            {

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "cos",//formula name
                    Formula_Eq = "cos(x)",//formula
                    RearrangedFormula_BeforCalculation = "cos(x)",//formula rearranged
                    Description = "cos of an angle",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "cos(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("tan"))
            {

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "tan",//formula name
                    Formula_Eq = "tan(x)",//formula
                    RearrangedFormula_BeforCalculation = "tan(x)",//formula rearranged
                    Description = "tan of an angle",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "tan(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }

            //-----------------SINCOSTAN H
            //-----------------SINCOSTAN H
            //-----------------SINCOSTAN H
            //-----------------SINCOSTAN H

            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("sinh"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "sinh",//formula name
                    Formula_Eq = "sinh(x)",//formula
                    RearrangedFormula_BeforCalculation = "sinh(x)",//formula rearranged
                    Description = "sinh of an angle",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "sinh(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("cosh"))
            {

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "cosh",//formula name
                    Formula_Eq = "cosh(x)",//formula
                    RearrangedFormula_BeforCalculation = "cosh(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "cosh(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("tanh"))
            {

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "tanh",//formula name
                    Formula_Eq = "tanh(x)",//formula
                    RearrangedFormula_BeforCalculation = "tanh(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "tanh(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }







            //-----------------ARC SINCOSTAN
            //-----------------ARC SINCOSTAN
            //-----------------ARC SINCOSTAN
            //-----------------ARC SINCOSTAN


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("asin"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "asin",//formula name
                    Formula_Eq = "asin(x)",//formula
                    RearrangedFormula_BeforCalculation = "asin(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "asin(x)"//formula formula use
                             //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("acos"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "acos",//formula name
                    Formula_Eq = "acos(x)",//formula
                    RearrangedFormula_BeforCalculation = "acos(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "acos(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("atan"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "atan",//formula name
                    Formula_Eq = "atan(x)",//formula
                    RearrangedFormula_BeforCalculation = "atan(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "atan(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }

            //-----------------ARC SINCOSTAN H
            //-----------------ARC SINCOSTAN H
            //-----------------ARC SINCOSTAN H
            //-----------------ARC SINCOSTAN H

            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("asinh"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "asinh",//formula name
                    Formula_Eq = "asinh(x)",//formula
                    RearrangedFormula_BeforCalculation = "asinh(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List = new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "asinh(x)"//formula formula use


                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("acosh"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "acosh",//formula name
                    Formula_Eq = "acosh(x)",//formula
                    RearrangedFormula_BeforCalculation = "acosh(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "acosh(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("atanh"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "atanh",//formula name
                    Formula_Eq = "atanh(x)",//formula
                    RearrangedFormula_BeforCalculation = "atanh(x)",//formula rearranged
                    Description = "",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "atanh(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            //====================Log/ln
            //====================Log/ln
            //====================Log/ln
            //====================Log/ln

            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("log"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "log",//formula name
                    Formula_Eq = "log(x)",//formula
                    RearrangedFormula_BeforCalculation = "log(x)",//formula rearranged
                    Description = "Log base 10",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "log(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("ln"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "ln",//formula name
                    Formula_Eq = "ln(x)",//formula
                    RearrangedFormula_BeforCalculation = "ln(x)",//formula rearranged
                    Description = "Log base e",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "ln(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("abs"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "abs",//formula name
                    Formula_Eq = "abs(x)",//formula
                    RearrangedFormula_BeforCalculation = "abs(x)",//formula rearranged
                    Description = "absolute value of x",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "abs(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("ceiling"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "ceiling",//formula name
                    Formula_Eq = "ceiling(x)",//formula
                    RearrangedFormula_BeforCalculation = "ceiling(x)",//formula rearranged
                    Description = "returns the highest integer",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "ceiling(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }


            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("floor"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "clamp",//formula name
                    Formula_Eq = "clamp(value,min,max)",//formula
                    RearrangedFormula_BeforCalculation = "clamp(value, min, max)",//formula rearranged
                    Description = "Set the value only between min or max",//formula Description
                    Variable_List = new ObservableCollection<Variable> {
                        new Variable(
                        //"x",//variable
                        "value",//variable name
                        "value",//variable value
                        "an expression"),
                        new Variable(
                        //"x",//variable
                        "min",//variable name
                        "min",//variable value
                        "minimum value"),
                        new Variable(
                        //"x",//variable
                        "max",//variable name
                        "max",//variable value
                        "maximum value"),

                    },
                },



                    "clamp(value,min,max)",//formula formula use
                    isMultiVarFunction: true


                    //variable Description
                    )
                );

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = -1 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 3;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }

            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("floor"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "floor",//formula name
                    Formula_Eq = "floor(x)",//formula
                    RearrangedFormula_BeforCalculation = "floor(x)",//formula rearranged
                    Description = "returns the lowest integer",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x")},
                },



                    "floor(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("fact!"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "fact!",//formula name
                    Formula_Eq = "fact!(x)",//formula
                    RearrangedFormula_BeforCalculation = "fact!(x)",//formula rearranged
                    Description = "returns the factorial of x; x is turned into an integer",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "x is an integer")},
                },



                    "fact!(x)"//formula formula use

                    //variable Description
                    ));
                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }



            if (!Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.ContainsKey("sum"))
            {
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Add(
                new Model.Formula.CustomButtons(new Formula()
                {
                    Name = "sum",//formula name
                    Formula_Eq = "sum(i,n,x)",//formula
                    RearrangedFormula_BeforCalculation = "sum(i,n,x)",//formula rearranged
                    Description = "Summation; Slow performance if upper limit n is set too high; Will loop;",//formula Description
                    Variable_List =
                    new ObservableCollection<Variable> { new Variable(
                        //"x",//variable
                        "i",//variable name
                        "i",//variable value
                        "index of summation (smaller or equal to n)"),
                        new Variable(
                        //"x",//variable
                        "n",//variable name
                        "n",//variable value
                        "upper limit of summation"),
                        new Variable(
                        //"x",//variable
                        "x",//variable name
                        "x",//variable value
                        "expression (can include \"i\")")
                    },
                },



                    "sum(i,n,x)",//formula formula use
                    isMultiVarFunction: true

                    //variable Description
                    ));

                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IsIgnoreCol = true;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.VariablesToIgnore = new ObservableCollection<StringBinding>() { new StringBinding() { Val="i" } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.ColumnsToIgnore = new ObservableCollection<IntBinding>() { new IntBinding() { Val = 2 } };
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.TotalNumberOfColumns = 3;
                Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.IgnoreAllVar = false;
                Main_Logic.main_Model.customButtons_SavedButtons_IsMultiVariabble_Dictionary.Add(
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last().Formula_Instance.Name,
                    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Last());

                int index = Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List.Count - 1;
                //Main_Logic.main_Model.customButtons_SavedButtons_Dictionary.Add(
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index].Formula_Instance.Name,
                //    Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab].CustomButtons_List[index]);
            }




            return Main_Logic.main_Model.CustomButtons_Tab_List[0].CustomButtons_SubTab[indexOfDefaultTab];
        }
    }
}
