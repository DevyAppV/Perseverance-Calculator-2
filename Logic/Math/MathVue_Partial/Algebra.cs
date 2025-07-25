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

        private (bool isRounded, string result) isRound(char numToRound)
        {

            switch (numToRound)
            {
                case '5':
                    return (true, "6");
                case '6':
                    return (true, "7");
                case '7':
                    return (true, "8");
                case '8':
                    return (true, "9");
                case '9':
                    return (true, "10");
                default:
                    return (false, "0");


            }
        }


        private string trim(Model.Formula.Formula formula_Obj, string functionExpression, Dictionary<string, string> splitStr, bool assignRearrange_OnMainThread)
        {

            double xParsed = 0;
            double yParsed = 0;
            //bool isRounded = 0;


            bool isXParsed = double.TryParse(solveParenthesis_Functions(removeNewLineAndSpacecs(setVariable(formula_Obj, splitStr["x"], splitStr)).Replace(']', ')').Replace('[', '('), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out xParsed);
            bool isYParsed = double.TryParse(solveParenthesis_Functions(removeNewLineAndSpacecs(setVariable(formula_Obj, splitStr["y"], splitStr)).Replace(']', ')').Replace('[', '('), formula_Obj, false, false, false), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out yParsed);
            if (isXParsed &&
            isYParsed)
            {
                string isRounded = solveParenthesis_Functions(removeNewLineAndSpacecs(setVariable(formula_Obj, splitStr["isRounded"], splitStr)).Replace(']', ')').Replace('[', '('), formula_Obj, false, false, false).Replace(']', ')').Replace('[', '(').Replace("(", "").Replace(")", "");


                string splitX = removeNewLineAndSpacecs(xParsed.ToString()).Replace(']', ')').Replace('[', '(').Replace("(", "").Replace(")", "");
                string splitY = removeNewLineAndSpacecs(yParsed.ToString()).Replace(']', ')').Replace('[', '(').Replace("(", "").Replace(")", "");

                splitX = replaceE_With0(splitX, "E-").result;
                splitX = replaceE_With0(splitX, "E+").result;

                splitY = replaceE_With0(splitY, "E-").result;
                splitY = replaceE_With0(splitY, "E+").result;
                //if (splitX.IndexOf('.') == indexOfDecimal + (int)yParsed)
                //{
                //    return splitX.Remove(indexOfDecimal + (int)yParsed);
                //}
                int indexOfDecimal = splitX.IndexOf('.');
                int negDec = splitX.IndexOf("-.");
                int hasDecimal = 0;
                int hasneg = splitX.StartsWith('-') ? 1 : 0;



                if (negDec != -1)
                {
                    splitX = splitX.Insert(negDec + 1, "0");
                    indexOfDecimal = splitX.IndexOf('.');
                }

                if (indexOfDecimal == 0)
                {
                    splitX = splitX.Insert(0, "0");
                    indexOfDecimal = splitX.IndexOf('.');
                }
                if (indexOfDecimal == -1)
                {
                    splitX += ".0";
                    indexOfDecimal = splitX.IndexOf(".");
                }
                hasDecimal = 1;

                if (isRounded.Equals("false"))
                {
                    if (indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1 < splitX.Length &&
                        indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1 >= 0)
                    {
                        //splitX = splitX.Insert(indexOfDecimal + (int)yParsed + 1, "0");
                        //return splitX.Remove(indexOfDecimal + (int)yParsed + 1);

                        if (indexOfDecimal + (int)yParsed + 1 - hasDecimal >= 0 &&
                            splitX[indexOfDecimal + (int)yParsed + 1 - hasDecimal].Equals('-')) return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                        else if (indexOfDecimal + (int)yParsed + 1 - hasDecimal < 0)
                        {
                            return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                        }
                        for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                        {
                            if (!splitX[i].Equals('.'))
                                splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                        }

                        return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                    }
                    else
                        return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                }
                else if (isRounded.Equals("true"))
                {
                    if (indexOfDecimal + (int)yParsed + 1 < splitX.Length &&
                        indexOfDecimal + (int)yParsed + 1 > 0)
                    {
                        int indexOfRound = 0;
                        if (splitX[indexOfDecimal + (int)yParsed + 1].Equals('.'))
                        {
                            if (indexOfDecimal + (int)yParsed + 2 < splitX.Length)
                            {
                                //splitX = splitX.Insert(indexOfDecimal + (int)yParsed + 3, "0");
                                //splitX = splitX.Remove(indexOfDecimal + (int)yParsed + 3);
                                indexOfRound = indexOfDecimal + (int)yParsed + 1 - hasDecimal;
                            }
                            else
                            {

                                for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                                {
                                    if (!splitX[i].Equals('.'))
                                        splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                                }

                                return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                            }
                        }
                        else
                        {

                            if (indexOfDecimal + (int)yParsed + 1 < splitX.Length)
                            {
                                //splitX = splitX.Insert(indexOfDecimal + (int)yParsed + 3, "0");
                                //splitX = splitX.Remove(indexOfDecimal + (int)yParsed + 3);
                                indexOfRound = indexOfDecimal + (int)yParsed + 1 - hasDecimal;
                            }
                            else
                            {
                                for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                                {
                                    if (!splitX[i].Equals('.'))
                                        splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                                }

                                return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                            }
                            //splitX = splitX.Insert(indexOfDecimal + (int)yParsed + 2, "0");
                            //splitX = splitX.Remove(indexOfDecimal + (int)yParsed + 2);
                            //indexOfRound = splitX.Length - 2;
                        }
                        if (splitX[indexOfRound].Equals('-')) return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                        int add10 = 0;
                        while (indexOfRound >= 0)
                        {
                            int addIfDecimal = 0;
                            if (indexOfRound + 1 < splitX.Length && splitX[indexOfRound + 1].Equals('.'))
                            {
                                //indexOfRound--;
                                addIfDecimal++;
                            }
                            (bool isRounded, string result) roundResult = isRound(splitX[indexOfRound + addIfDecimal + 1]);
                            if (roundResult.isRounded || add10 == 1)
                            {
                                int result = -1;
                                if (roundResult.result.Equals("10"))
                                {
                                    add10 = 1;
                                    if (int.TryParse(splitX[indexOfRound].ToString(), out result))
                                    {
                                        //if (indexOfRound == 0)
                                        //{
                                        //    indexOfRound++;
                                        //    splitX = splitX.Insert(0, "1");
                                        //}
                                        //else
                                        //{
                                        if (result + add10 == 10)
                                        {
                                            splitX = splitX.Insert(indexOfRound, "0").Remove(indexOfRound + 1, 1);
                                            if (indexOfRound - hasneg == 0)
                                            {
                                                splitX = splitX.Insert(indexOfRound, "1");
                                                indexOfRound--;
                                            }
                                        }
                                        else
                                        {
                                            splitX = splitX.Insert(indexOfRound, (result + add10).ToString()).Remove(indexOfRound + 1, 1);

                                            for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                                            {
                                                if (!splitX[i].Equals('.'))
                                                    splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                                            }

                                            return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                                        }
                                        //}
                                    }
                                }
                                else
                                {
                                    if (int.TryParse(splitX[indexOfRound].ToString(), out result))
                                    {
                                        if (result + 1 == 10)
                                        {
                                            splitX = splitX.Insert(indexOfRound, "0").Remove(indexOfRound + 1, 1);
                                            add10 = 1;
                                            if (indexOfRound - hasneg == 0)
                                            {
                                                //indexOfRound++;
                                                splitX = splitX.Insert(indexOfRound, "1");
                                                indexOfRound--;
                                            }
                                        }
                                        else
                                        {
                                            if (add10 == 0)
                                                splitX = splitX.Insert(indexOfRound, (result + 1 + add10).ToString()).Remove(indexOfRound + 1, 1);
                                            else
                                                splitX = splitX.Insert(indexOfRound, (result + add10).ToString()).Remove(indexOfRound + 1, 1);

                                            //if (indexOfDecimal >= indexOfRound && add10 == 0)
                                            //{
                                            //    splitX = splitX.Insert(indexOfRound + 1, "0").Remove(indexOfRound + 2, 1);
                                            //}
                                            if (add10 == 1) add10 = 0;
                                            if (result + 1 + add10 != 10)
                                            {

                                                for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                                                {
                                                    if (!splitX[i].Equals('.'))
                                                        splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                                                }

                                                return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                                                //break;
                                            }
                                        }

                                    }
                                }
                            }
                            else
                            {
                                for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                                {
                                    if (!splitX[i].Equals('.'))
                                        splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                                }

                                return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                            }

                            indexOfRound--;
                        }
                        for (int i = indexOfDecimal + (int)yParsed + 1 - hasDecimal + 1; i < splitX.Length; i++)
                        {
                            if (!splitX[i].Equals('.'))
                                splitX = splitX.Insert(i, "0").Remove(i + 1, 1);
                        }

                        return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                    }
                    else
                        return solveParenthesis_Functions(splitX, formula_Obj, false, true, false);
                }

                else return "Error";
            }
            else return "Error";
        }

        private string factorial(string value)
        {
            string returnVal = "";
            int indexofDecimal = value.IndexOf(".");
            if (typeof(T).Equals(typeof(decimal)))
            {
                decimal result = 1;
                decimal valueDecimal = System.Math.Floor(decimal.Parse(value));

                for (decimal i = valueDecimal; i > 0; i--)
                {
                    result *= i;
                }
                returnVal = result.ToString();
            }
            else if (typeof(T).Equals(typeof(double)))
            {

                double result = 1;
                double valueDecimal = System.Math.Floor(double.Parse(value));

                for (double i = valueDecimal; i > 0; i--)
                {
                    result *= i;
                }
                returnVal = result.ToString();
            }
            return returnVal;
        }
    }
}
