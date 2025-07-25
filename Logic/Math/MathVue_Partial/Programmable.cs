using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Logic.Math
{
    public partial class MathVue<T>
    {

        //private string var(Formula formula_Obj, string functionExpression, string functionName, Dictionary<string, string> splitStr, bool assignRearrange_OnMainThread)
        //{
        //    double parsedValue = double.NaN;
        //    bool parsed1 = double.TryParse(solveParenthesis_Functions(splitStr["x"], null, true, true, false), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out parsedValue);

        //    if (parsed1)
        //    {
        //        if (formula_Obj != null)
        //        {
        //            if (!formula_Obj.varFunc_Variable_Dictionary.ContainsKey(splitStr["Name"]))
        //            {
        //                formula_Obj.varFunc_Variable_Dictionary.Add(splitStr["Name"], parsedValue.ToString());
        //            }
        //            else
        //            {
        //                formula_Obj.varFunc_Variable_Dictionary[splitStr["Name"]] = parsedValue.ToString();
        //            }
        //        }
        //        return "";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        private string orThen(Formula formula_Obj, string functionExpression, Dictionary<string, string> splitStr, bool assignRearrange_OnMainThread)
        {
            bool boolResult = false;
            //try
            //{
            if (removeNewLineAndSpacecs(splitStr["x"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals("true") ||
                removeNewLineAndSpacecs(splitStr["y"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals("true"))
            {
                boolResult = true;
            }

            if (boolResult)
            {
                //if (splitStr["trueReturn"].Contains("throw"))
                //{
                //    //throw new Exception(splitStr["trueReturn"]);
                //    return splitStr["trueReturn"];
                //}
                return splitStr["trueReturn"];
            }
            else
            {
                //if (splitStr["falseReturn"].Contains("throw"))
                //{
                //    //throw new Exception(splitStr["falseReturn"]);
                //    return splitStr["falseReturn"];
                //}
                return splitStr["falseReturn"];
            }
            //}
            //catch
            //{
            //    throw new Exception("Program Error");
            //}
        }
        private string ifThen(Formula formula_Obj, string functionExpression, Dictionary<string, string> splitStr, bool assignRearrange_OnMainThread)
        {
            bool boolResult = false;

            //try
            //{


            if (typeof(T).Equals(typeof(double)))
            {
                double x = 0;
                double y = 0;
                bool xParsed = double.TryParse(solveParenthesis_Functions(removeNewLineAndSpacecs(splitStr["x"].Replace(']', ')').Replace('[', '(')), formula_Obj, false, false, false).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", ""), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out x);


                bool yParsed = double.TryParse(solveParenthesis_Functions(removeNewLineAndSpacecs(splitStr["y"].Replace(']', ')').Replace('[', '(')), formula_Obj, false, false, false).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", ""), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out y);


                //double x = double.Parse(solveParenthesis_Functions(setVariable(formula_Obj, splitStr["x"], splitStr), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any);


                //double y = double.Parse(solveParenthesis_Functions(setVariable(formula_Obj, splitStr["y"], splitStr), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any);
                if (xParsed && yParsed)
                {
                    switch (splitStr["rOperator"])
                    {
                        case ">":
                            if (x > y)
                                boolResult = true;
                            break;
                        case "<":
                            if (x < y)
                                boolResult = true;
                            break;
                        case ">=":
                            if (x >= y)
                                boolResult = true;
                            break;
                        case "<=":
                            if (x <= y)
                                boolResult = true;
                            break;
                        case "==":
                            if (x == y)
                                boolResult = true;
                            break;
                        case "!=":
                            if (x != y)
                                boolResult = true;
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    //bool xx = false;
                    //bool yy = false;
                    //if (splitStr["x"].Contains("true"))
                    //    xx = true;
                    //if (splitStr["y"].Contains("true"))
                    //    yy = true;

                    //string s = splitStr["rOperator"];
                    switch (splitStr["rOperator"])
                    {
                        case "==":
                            if (removeNewLineAndSpacecs(splitStr["x"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals(
                                removeNewLineAndSpacecs(splitStr["y"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")))
                                boolResult = true;
                            break;
                        case "!=":
                            if (!removeNewLineAndSpacecs(splitStr["x"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals(
                                removeNewLineAndSpacecs(splitStr["y"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")))
                                boolResult = true;
                            break;
                        default:
                            boolResult = false;
                            break;

                    }
                }
            }
            else
            {

                decimal x = 0;
                decimal y = 0;
                bool xParsed = decimal.TryParse(solveParenthesis_Functions(setVariable(formula_Obj, splitStr["x"], splitStr), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out x);


                bool yParsed = decimal.TryParse(solveParenthesis_Functions(setVariable(formula_Obj, splitStr["y"], splitStr), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out y);
                if (xParsed && yParsed)
                {
                    switch (splitStr["rOperator"])
                    {
                        case ">":
                            if (x > y)
                                boolResult = true;
                            break;
                        case "<":
                            if (x < y)
                                boolResult = true;
                            break;
                        case ">=":
                            if (x >= y)
                                boolResult = true;
                            break;
                        case "<=":
                            if (x <= y)
                                boolResult = true;
                            break;
                        case "==":
                            if (x == y)
                                boolResult = true;
                            break;
                        case "!=":
                            if (x != y)
                                boolResult = true;
                            break;
                        default:
                            break;

                    }

                }
                else
                {
                    //bool xx = false;
                    //bool yy = false;
                    //if (splitStr["x"].Contains("true"))
                    //    xx = true;
                    //if (splitStr["y"].Contains("true"))
                    //    yy = true;

                    //string s = splitStr["rOperator"];
                    switch (splitStr["rOperator"])
                    {
                        case "==":
                            if (removeNewLineAndSpacecs(splitStr["x"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals(
                                removeNewLineAndSpacecs(splitStr["y"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")))
                                boolResult = true;
                            break;
                        case "!=":
                            if (!removeNewLineAndSpacecs(splitStr["x"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Equals(
                                removeNewLineAndSpacecs(splitStr["y"]).Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")))
                                boolResult = true;
                            break;
                        default:
                            boolResult = false;
                            break;

                    }
                }
                //else return "Program Error";
            }
            //}
            //catch
            //{
            //    throw new Exception("Program Error");
            //}

            if (boolResult)
            {
                //if (splitStr["trueReturn"].Contains("throw"))
                //{
                //    //throw new Exception(splitStr["trueReturn"]);
                //    return splitStr["trueReturn"];
                //}
                return splitStr["trueReturn"];
            }
            else
            {
                //if (splitStr["falseReturn"].Contains("throw"))
                //{
                //    //throw new Exception(splitStr["falseReturn"]);
                //    return splitStr["falseReturn"];
                //}
                return splitStr["falseReturn"];
            }
        }
    }
}
