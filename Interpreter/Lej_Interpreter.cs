using Microsoft.Windows.Widgets.Feeds.Providers;
using Perseverance_Calculator_2.Model;
using Perseverance_Calculator_2.Model.Formula;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Security.Cryptography.Core;

namespace Perseverance_Calculator_2.Interpreter
{
    public class Lej_Interpreter : NotifyPropChanged_Base
    {
        [XmlIgnore]
        public Dictionary<string, Lej_Interpreter_Abstract> lej_Interpreter_Abstract_Dictionary = new Dictionary<string, Lej_Interpreter_Abstract>();
        public string formula = "";

        public ObservableCollection<Variable> currentVariableList = new ObservableCollection<Variable>();
        [XmlIgnore]
        public Dictionary<string, Variable> newVariableList = new Dictionary<string, Variable>();
        public string formulaSolution = "";
        //private string? strToInterpret;
        private int index = 0;

        public ObservableCollection<Variable> CurrentVariableList
        {
            get { return currentVariableList; }
            set
            {
                currentVariableList = value;
                OnPropertyChanged("CurrentVariableList");
            }
        }
        public Lej_Interpreter() { }
        public Lej_Interpreter(ObservableCollection<Variable> variableList)
        {
            currentVariableList = variableList;
        }
        //public Lej_Interpreter(string strToInterpret) { 

        //    //this.strToInterpret = strToInterpret;
        //}


        public void execute()
        {
            //string? result = "";
            foreach (KeyValuePair<string, Lej_Interpreter_Abstract> obj in lej_Interpreter_Abstract_Dictionary)
            {

                formulaSolution = exectution(obj);

            }
            getVar();
        }


        public void getVar()
        {

            Dictionary<string, Variable> varToAdd = new Dictionary<string, Variable>();
            Dictionary<string, Variable> currentVar = new Dictionary<string, Variable>();

            //!contain prev var
            for (int i = 0; i < currentVariableList.Count(); i++)
            {

                if (!newVariableList.ContainsKey(currentVariableList[i].Name))
                {
                    currentVariableList.RemoveAt(i);
                }
                else { currentVar.Add(currentVariableList[i].Name, currentVariableList[i]); }

            }
            //!contain New Var
            for (int q = 0; q < newVariableList.Count(); q++)
            {

                if (!currentVar.ContainsKey(newVariableList.ElementAt(q).Key))
                {
                    varToAdd.Add(newVariableList.ElementAt(q).Key, newVariableList.ElementAt(q).Value);
                }

            }

            foreach (KeyValuePair<string, Variable> v in varToAdd)
            {
                currentVariableList.Add(v.Value);
            }


        }


        private string exectution(KeyValuePair<string, Lej_Interpreter_Abstract> obj)
        {
            //if (obj.Value.keyword.Equals("string"))
            //{

            //}
            //else if (obj.Value.keyword.Equals("double"))
            //{

            //}
            //else if (obj.Value.keyword.Equals("bool"))
            //{

            //}
            //else if (obj.Value.keyword.Equals("void"))
            //{

            //}
            return "";
        }

        public void interpret(string strToInterpret)
        {
            if (!string.IsNullOrEmpty(strToInterpret))
            {
                newVariableList.Clear();
                lej_Interpreter_Abstract_Dictionary.Clear();
                //int numOpenPar = 0;
                //int numClosePar = 0;
                //int numOpenBraces = 0;
                //int numCloseBraces = 0;
                //int numOpenBrackets = 0;
                //int numCloseBrackets = 0;

                //bool doesVarExist = false;
                bool isAdded_Var_Val = false;
                //bool isNextVarPublic = false;
                bool isReadySetVar = false;
                bool isFunctionBody = false;
                bool isConditional = false;
                bool isLoop = false;
                bool isMath = false;
                string curMath = "";

                bool isEqual = false;
                bool isGreater = false;
                bool isGreaterEqual = false;
                bool isLess = false;
                bool isLessEqual = false;
                bool isNot = false;
                bool isNotEqual = false;


                //bool isLoopVar1_Set = false;
                Lej_Interpreter_Abstract lej_Abstract_Variables = new Lej_Interpreter_Abstract();

                if (lej_Interpreter_Abstract_Dictionary != null)
                {
                    for (; index < strToInterpret.Length; index++)
                    {
                        (string TokenStr, bool isNewToken, string isNewToken_Str) lexerToken = Lej_Interpreter_Lexer.getLexerToken(strToInterpret, ref index);
                        Lej_Interpreter_Lexer.TokenType? tokenType = Lej_Interpreter_Parser.parseGetLexerToken(ref lexerToken.TokenStr);



                        if (!lexerToken.TokenStr.Equals(""))
                        {

                            if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Variable))
                            {

                                //if (lej_Interpreter_Abstract_Dictionary != null && lej_Interpreter_Abstract_Dictionary.ContainsKey(lexerToken.TokenStr))
                                //{
                                //    doesVarExist = true;
                                //}
                                //else
                                //    doesVarExist = false;


                                isAdded_Var_Val = true;
                                lej_Abstract_Variables.isVariable = true;


                                ////////////////////////////////////if (isNextVarPublic)
                                ////////////////////////////////////{

                                ////////////////////////////////////    bool containsVariable = false;
                                ////////////////////////////////////    lej_Abstract_Variables.isPublicVar = true;
                                ////////////////////////////////////    if (!containsVariable)
                                ////////////////////////////////////    {
                                ////////////////////////////////////        newVariableList.Add(lexerToken.TokenStr, new Variable() { Name = lexerToken.TokenStr });
                                ////////////////////////////////////    }
                                ////////////////////////////////////    isNextVarPublic = false;

                                ////////////////////////////////////}
                                if (isFunctionBody)
                                {
                                    lej_Abstract_Variables.variableName = lexerToken.TokenStr;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = lexerToken.TokenStr });
                                }
                                else if (isLoop || isConditional)
                                {
                                    setLejAbstractValue_BasedOnConditional(ref lej_Abstract_Variables, lexerToken, isEqual, isGreater,
                                        isGreaterEqual, isLess, isLessEqual, isNot, isNotEqual);
                                    //isConditional = false;
                                    //isLoop = false;
                                }
                                else if (!string.IsNullOrWhiteSpace(lej_Abstract_Variables.variableName))
                                {
                                    curMath += lexerToken.TokenStr;
                                }
                                else
                                {
                                    lej_Abstract_Variables.variableName = lexerToken.TokenStr;
                                }
                            }
                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Equal))
                            {
                                isAdded_Var_Val = true;
                                isReadySetVar = true;
                            }
                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Value))
                            {
                                isAdded_Var_Val = true;
                                double result = double.NaN;

                                if(isMath)
                                    curMath += lexerToken.TokenStr;
                                else if (isReadySetVar)
                                {
                                    if (isFunctionBody)
                                    {
                                        lej_Abstract_Variables.value += lexerToken.TokenStr;

                                        if (lexerToken.TokenStr.Equals("true") || lexerToken.TokenStr.Equals("false"))
                                        {
                                            lej_Abstract_Variables.isBoolean = true;
                                        }
                                        else if (lexerToken.TokenStr.Length > 2 &&
                                            lexerToken.TokenStr.StartsWith('\'') && lexerToken.TokenStr.EndsWith('\'') &&
                                            lexerToken.TokenStr.LastIndexOf('\'') != lexerToken.TokenStr.IndexOf('\''))
                                        {
                                            lej_Abstract_Variables.isString = true;
                                        }
                                        else if (double.TryParse(lexerToken.TokenStr, out result))
                                        {
                                            lej_Abstract_Variables.isDouble = true;
                                        }
                                        else
                                        {
                                            result = double.NaN;
                                        }
                                    }

                                    else
                                    {
                                        lej_Abstract_Variables.value += lexerToken.TokenStr;
                                        if (lexerToken.TokenStr.Equals("true") || lexerToken.TokenStr.Equals("false"))
                                        {
                                            lej_Abstract_Variables.isBoolean = true;
                                        }
                                        else if (lexerToken.TokenStr.Length > 2 &&
                                            lexerToken.TokenStr.StartsWith('\'') && lexerToken.TokenStr.EndsWith('\'') &&
                                            lexerToken.TokenStr.LastIndexOf('\'') != lexerToken.TokenStr.IndexOf('\''))
                                        {
                                            lej_Abstract_Variables.isString = true;
                                        }
                                        else if (double.TryParse(lexerToken.TokenStr, out result))
                                        {
                                            lej_Abstract_Variables.isDouble = true;
                                        }
                                        else
                                        {
                                            result = double.NaN;
                                        }
                                    }


                                    if (lexerToken.isNewToken_Str.Equals(";") || lexerToken.isNewToken_Str.Equals(","))
                                    {
                                        if (string.IsNullOrWhiteSpace(lej_Abstract_Variables.variableName))
                                        {
                                            if (lej_Interpreter_Abstract_Dictionary != null && !lej_Interpreter_Abstract_Dictionary.ContainsKey(lej_Abstract_Variables.variableName))
                                            {
                                                lej_Interpreter_Abstract_Dictionary.Add("", null);
                                                lej_Interpreter_Abstract_Dictionary.Last().Value.lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables);
                                            }
                                            else
                                            {
                                                lej_Interpreter_Abstract_Dictionary?[lej_Abstract_Variables.variableName].lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables);
                                            }
                                        }
                                        else
                                        {
                                            if (lej_Interpreter_Abstract_Dictionary != null && !lej_Interpreter_Abstract_Dictionary.ContainsKey(lej_Abstract_Variables.variableName))
                                            {
                                                lej_Interpreter_Abstract_Dictionary.Add(lej_Abstract_Variables.variableName, lej_Abstract_Variables);
                                            }
                                            else
                                            {
                                                lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.variableName] = lej_Abstract_Variables;
                                                //lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.variableName].=lej_Abstract_Variables.variableName;
                                            }
                                        }

                                        //if (!string.IsNullOrWhiteSpace(lexerToken.isNewToken_Str))
                                        //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                    }

                                    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                    //isReadySetVar = false;
                                }
                                else if (isLoop || isConditional)
                                {
                                    isAdded_Var_Val = true;
                                    if (lexerToken.TokenStr.Equals("true") || lexerToken.TokenStr.Equals("false"))
                                    {
                                        lej_Abstract_Variables.isBoolean = true;
                                    }
                                    else if (lexerToken.TokenStr.Length > 2 &&
                                        lexerToken.TokenStr.StartsWith('\'') && lexerToken.TokenStr.EndsWith('\'') &&
                                        lexerToken.TokenStr.LastIndexOf('\'') != lexerToken.TokenStr.IndexOf('\''))
                                    {
                                        lej_Abstract_Variables.isString = true;
                                    }
                                    else if (double.TryParse(lexerToken.TokenStr, out result))
                                    {
                                        lej_Abstract_Variables.isDouble = true;
                                    }
                                    else
                                    {
                                        result = double.NaN;
                                    }
                                    setLejAbstractValue_BasedOnConditional(ref lej_Abstract_Variables, lexerToken, isEqual, isGreater,
                                        isGreaterEqual, isLess, isLessEqual, isNot, isNotEqual);

                                    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();

                                    //isConditional = false;
                                    //isLoop = false;
                                }
                            }


                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Loop))
                            {
                                isAdded_Var_Val = true;
                                if (lexerToken.TokenStr.Equals("while"))
                                {
                                    isLoop = true;
                                    lej_Abstract_Variables.variableName = "while";
                                }
                                else if (lexerToken.TokenStr.Equals("foreach"))
                                {
                                    isLoop = true;
                                    lej_Abstract_Variables.variableName = "foreach";
                                }
                            }



                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Conditional))
                            {
                                isAdded_Var_Val = true;
                                isConditional = true;
                                lej_Abstract_Variables = new Lej_Interpreter_Abstract() { isContainedWithin_FunctionName = lej_Abstract_Variables.isContainedWithin_FunctionName };
                                if (lexerToken.TokenStr.Equals("if"))
                                {
                                    lej_Abstract_Variables.variableName = "if";
                                }
                                else if (lexerToken.TokenStr.Equals("elseif"))
                                {
                                    lej_Abstract_Variables.variableName = "elseif";
                                }
                                else if (lexerToken.TokenStr.Equals("else"))
                                {
                                    lej_Abstract_Variables.variableName = "else";
                                }

                            }



                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.ComparisonOperator))
                            {
                                isAdded_Var_Val = true;
                                isConditional = true;
                                if (lexerToken.TokenStr.Equals("=="))
                                {
                                    isEqual = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "if" });
                                }
                                else if (lexerToken.TokenStr.Equals(">"))
                                {
                                    isGreater = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "elseif" });
                                }
                                else if (lexerToken.TokenStr.Equals(">="))
                                {
                                    isGreaterEqual = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "else" });
                                }
                                else if (lexerToken.TokenStr.Equals("<"))
                                {
                                    isLess = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "else" });
                                }
                                else if (lexerToken.TokenStr.Equals("<="))
                                {
                                    isLessEqual = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "else" });
                                }
                                else if (lexerToken.TokenStr.Equals("!"))
                                {
                                    isNot = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "else" });
                                }
                                else if (lexerToken.TokenStr.Equals("!="))
                                {
                                    isNotEqual = true;
                                    //lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(new Lej_Interpreter_Abstract() { variableName = "else" });
                                }

                            }





                            //ARRAY
                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Bracket_Open))
                            {
                                isAdded_Var_Val = true;
                                //numOpenBrackets++;
                                //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                            }

                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Bracket_Close))
                            {
                                isAdded_Var_Val = true;
                                //numCloseBrackets++;
                                //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                            }




                            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Math))
                            {
                                isMath = true;
                                if (!isReadySetVar)
                                {
                                    curMath += lej_Abstract_Variables.variableName+lexerToken.TokenStr;
                                    lej_Abstract_Variables.variableName = "";
                                }
                                else
                                {
                                    curMath += lej_Abstract_Variables.value+lexerToken.TokenStr;
                                    lej_Abstract_Variables.value = "";
                                }
                                //isAdded_Var_Val = true;
                                //numCloseBrackets++;
                                //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                            }
















                            //////////////////////////////////////////public == add to get var
                            ////////////////////////////////////////else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Public))
                            ////////////////////////////////////////{
                            ////////////////////////////////////////    isAdded_Var_Val = true;
                            ////////////////////////////////////////    isNextVarPublic = true;
                            ////////////////////////////////////////    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                            ////////////////////////////////////////}





















                            if (isAdded_Var_Val)
                            {
                                isAdded_Var_Val = false;
                                if (lexerToken.isNewToken_Str.Equals(";"))
                                {
                                    //numOpenPar++;
                                    //if (!isConditional && !isLoop)
                                    //{
                                    //    isFunctionBody = true;
                                    //}
                                    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();

                                    if (isMath)
                                    {
                                        //curMath += lej_Abstract_Variables.variableName;
                                        //lej_Abstract_Variables.variableName = "";
                                        lej_Abstract_Variables.value = curMath;
                                        curMath = "";
                                        isMath = false;
                                    }
                                    isReadySetVar = false;


                                    isLoop = false;
                                    isConditional = false;
                                    setLej_BasedOn_Name(ref lej_Abstract_Variables, isConditional, isLoop);
                                    if (isFunctionBody)
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract() { isContainedWithin_FunctionName = lej_Abstract_Variables.isContainedWithin_FunctionName };
                                    else
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                }


                                else if (lexerToken.isNewToken_Str.Equals(","))
                                {
                                    if (isMath)
                                    {
                                        //curMath += lej_Abstract_Variables.variableName;
                                        //lej_Abstract_Variables.variableName = "";
                                        lej_Abstract_Variables.value = curMath;
                                        curMath = "";
                                        isMath = false;
                                    }
                                    isReadySetVar = false;


                                    isLoop = false;
                                    isConditional = false;
                                    setLej_BasedOn_Name(ref lej_Abstract_Variables, isConditional, isLoop);
                                    if (isFunctionBody)
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract() { isContainedWithin_FunctionName = lej_Abstract_Variables.isContainedWithin_FunctionName };
                                    else
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                    //numOpenPar++;
                                    //if (!isConditional && !isLoop)
                                    //{
                                    //    isFunctionBody = true;
                                    //}
                                    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                }


                                else if (lexerToken.isNewToken_Str.Equals("("))
                                {
                                    //numOpenPar++;
                                    if (!isConditional && !isLoop)
                                    {
                                        isFunctionBody = true;
                                        lej_Abstract_Variables.isContainedWithin_FunctionName = lexerToken.TokenStr;
                                        //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                    }
                                    setLej_BasedOn_Name(ref lej_Abstract_Variables, isConditional, isLoop);
                                }

                                else if (lexerToken.isNewToken_Str.Equals(")"))
                                {
                                    if (isFunctionBody)
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract() { isContainedWithin_FunctionName = lej_Abstract_Variables.isContainedWithin_FunctionName };
                                    else
                                        lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                }

                                else if (lexerToken.isNewToken_Str.Equals("{"))
                                {
                                    if (!isConditional && !isLoop)
                                    {
                                        isFunctionBody = true;
                                    }
                                    if (lej_Abstract_Variables.variableName.Equals("else"))
                                    {
                                        setLej_BasedOn_Name(ref lej_Abstract_Variables, isConditional, isLoop);
                                        if (isFunctionBody)
                                            lej_Abstract_Variables = new Lej_Interpreter_Abstract() { isContainedWithin_FunctionName = lej_Abstract_Variables.isContainedWithin_FunctionName };
                                        else
                                            lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                    }
                                    //numOpenBraces++;
                                    //lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                }

                                else if (lexerToken.isNewToken_Str.Equals("}"))
                                {
                                    //numCloseBraces++;
                                    isFunctionBody = false;
                                    isLoop = false;
                                    isConditional = false;
                                    setLej_BasedOn_Name(ref lej_Abstract_Variables, isConditional, isLoop);
                                    lej_Abstract_Variables = new Lej_Interpreter_Abstract();
                                }



                            }



                        }


                    }
                }

                index = 0;

            }

        }


        private void setLej_BasedOn_Name(ref Lej_Interpreter_Abstract lej_Abstract_Variables, bool isConditional, bool isLoop)
        {
            if (isConditional || isLoop)
            {
                if (string.IsNullOrWhiteSpace(lej_Abstract_Variables.isContainedWithin_FunctionName))
                {
                    if (!lej_Interpreter_Abstract_Dictionary.ContainsKey(""))
                        lej_Interpreter_Abstract_Dictionary.Add("", new Lej_Interpreter_Abstract());
                    lej_Interpreter_Abstract_Dictionary[""].lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables);
                }
                else if (lej_Interpreter_Abstract_Dictionary.ContainsKey(lej_Abstract_Variables.isContainedWithin_FunctionName))
                {
                    lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.isContainedWithin_FunctionName].lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables);
                }
            }
            else if (!(isConditional || isLoop))
            {

                if (lej_Interpreter_Abstract_Dictionary.ContainsKey(lej_Abstract_Variables.variableName))
                {
                    lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.variableName] = lej_Abstract_Variables;
                }
                else
                {
                    lej_Interpreter_Abstract_Dictionary.Add(lej_Abstract_Variables.variableName, lej_Abstract_Variables);
                }
            }
        }


        private void setLejAbstractValue_BasedOnConditional(
            ref Lej_Interpreter_Abstract lej_Abstract_Variables,
            (string TokenStr, bool isNewToken, string isNewToken_Str) lexerToken,
            bool isEqual,
            bool isGreater,
            bool isGreaterEqual,
            bool isLess,
            bool isLessEqual,
            bool isNot,
            bool isNotEqual
            )
        {
            if (
                (lej_Abstract_Variables.variableName.Equals("if") ||
                lej_Abstract_Variables.variableName.Equals("elseif") ||
                lej_Abstract_Variables.variableName.Equals("else") ||
                lej_Abstract_Variables.variableName.Equals("while") ||
                lej_Abstract_Variables.variableName.Equals("foreach")
                ))
            {
                if (string.IsNullOrWhiteSpace(lej_Abstract_Variables.value))
                {
                    lej_Abstract_Variables.value = lexerToken.TokenStr;
                    return;
                }
                //lej_Interpreter_Abstract_List_LeftVal = lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.lej_Interpreter_Abstract_List.Last().variableName].value;

            }

            double resultLeft = double.NaN;
            double resultRight = double.NaN;
            bool isLexerStr_Bool = (lexerToken.TokenStr.Equals("true") || lexerToken.TokenStr.Equals("false")) ? true : false;
            bool isLexerStr_Double = (double.TryParse(lexerToken.TokenStr, out resultLeft)) ? true : false;
            bool isLexerStr_String = (lexerToken.TokenStr.Contains('\'')) ? true : false;

            if (!isLexerStr_Double) { resultLeft = double.NaN; }

            string lej_Interpreter_Abstract_List_LeftVal = "";
            string lej_Interpreter_Abstract_List_RightVal = "";

            if (lej_Abstract_Variables.isBoolean ||
                lej_Abstract_Variables.isString ||
                lej_Abstract_Variables.isDouble)
            {
                lej_Interpreter_Abstract_List_LeftVal = lej_Abstract_Variables.value;
            }
            else if (lej_Abstract_Variables.isVariable)
            {
                lej_Interpreter_Abstract_List_LeftVal = lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.value].value;

            }
            else
            {
                lej_Interpreter_Abstract_List_LeftVal = lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.variableName].value;
            }

            if (!isLexerStr_Double && !isLexerStr_Bool && !isLexerStr_String)
            {
                lej_Interpreter_Abstract_List_RightVal = lej_Interpreter_Abstract_Dictionary[lexerToken.TokenStr].value;

                //lej_Interpreter_Abstract_List_RightVal = lexerToken.TokenStr;
            }
            else
            {
                lej_Interpreter_Abstract_List_RightVal = lexerToken.TokenStr;
                if (!double.TryParse(lexerToken.TokenStr, out resultRight)) { resultRight = double.NaN; }
            }
            //else
            //{
            //    lej_Interpreter_Abstract_List_RightVal = lej_Interpreter_Abstract_Dictionary[lej_Abstract_Variables.variableName].value;
            //}


            if (isEqual)
            {
                if (lej_Interpreter_Abstract_List_LeftVal.Equals(lej_Interpreter_Abstract_List_RightVal))
                {
                    lej_Abstract_Variables.value = "true";
                }
                else
                {
                    lej_Abstract_Variables.value = "false";
                }
                isEqual = false;
            }
            else if (isGreater)
            {
                if (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN) &&
                    resultLeft > resultRight)
                {
                    lej_Abstract_Variables.value = "true";

                }
                else
                {

                    lej_Abstract_Variables.value = "false";
                }

                isGreater = false;
            }
            else if (isGreaterEqual)
            {
                if (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN) &&
                    resultLeft >= resultRight)
                {
                    lej_Abstract_Variables.value = "true";

                }
                else
                {

                    lej_Abstract_Variables.value = "false";
                }

                isGreaterEqual = false;
            }
            else if (isLess)
            {

                if (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN) &&
                    resultLeft < resultRight)
                {
                    lej_Abstract_Variables.value = "true";

                }
                else
                {

                    lej_Abstract_Variables.value = "false";
                }

                isLess = false;
            }
            else if (isLessEqual)
            {
                if (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN) &&
                    resultLeft <= resultRight)
                {
                    lej_Abstract_Variables.value = "true";

                }
                else
                {

                    lej_Abstract_Variables.value = "false";
                }


                isLessEqual = false;
            }
            else if (isNot)
            {

                if (isLexerStr_Bool)
                {
                    lej_Abstract_Variables.value = "false";
                }
                else
                {

                    lej_Abstract_Variables.value = "true";
                }

                isNot = false;
            }
            else if (isNotEqual)
            {

                if ((
                    (isLexerStr_Bool && lej_Abstract_Variables.isBoolean) ||
                    (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN)) ||
                    (lexerToken.TokenStr.Contains("\'") && lej_Abstract_Variables.isString)
                    ) &&
                    (!lej_Interpreter_Abstract_List_LeftVal.Equals(lej_Interpreter_Abstract_List_RightVal) ||
                    (!resultLeft.Equals(double.NaN) && !resultRight.Equals(double.NaN) && resultLeft != resultRight)
                    ))
                {
                    lej_Abstract_Variables.value = "true";

                }
                else
                {

                    lej_Abstract_Variables.value = "false";
                }

                isNotEqual = false;
            }
            else
            {
                lej_Abstract_Variables.value = lexerToken.TokenStr;
            }
        }
    }
}





//}



//}

//public void interpret(string strToInterpret)
//{
//    if (!string.IsNullOrEmpty(strToInterpret))
//    {
//        //variable
//        Lej_Interpreter_Abstract lej_Abstract_Variables = new Lej_Interpreter_Abstract();
//        //functionVariables
//        Lej_Interpreter_Abstract lej_Abstract_FunctionBody_Variables = new Lej_Interpreter_Abstract();
//        //lej_Abstract.lej_Interpreter_Abstract_List.Add(strToInterpret, new Lej_Interpreter_Abstract());
//        lej_Interpreter_Abstract_List.Clear();

//        formula = "";
//        bool isKeyword = false;
//        bool isFunctionParameter = false;
//        bool isFunctionBody = false;
//        //new Lej_Interpreter_Abstract() { keyword = token };
//        for (; index < strToInterpret.Length; index++)
//        {
//            (string TokenStr, bool isNewToken, string isNewTokenStr) token = Lej_Interpreter_Lexer.getLexerToken(strToInterpret, ref index);
//            Lej_Interpreter_Lexer.TokenType? tokenType = Lej_Interpreter_Parser.parseGetLexerToken(ref token.TokenStr);



//            if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Keyword))
//            {
//                isKeyword = true;
//                lej_Abstract_Variables.keyword = token.TokenStr;
//                if (isFunctionParameter || isFunctionBody)
//                {
//                    lej_Abstract_FunctionBody_Variables.keyword = token.TokenStr;
//                }
//            }
//            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Variable))
//            {
//                if (string.IsNullOrEmpty(lej_Abstract_Variables.variableName))
//                {
//                    if (isKeyword)
//                    {
//                        if (isFunctionParameter || isFunctionBody)
//                        {
//                            lej_Abstract_FunctionBody_Variables.variableName = token.TokenStr;
//                        }
//                        else
//                        {
//                            lej_Abstract_Variables.variableName = token.TokenStr;
//                        }
//                    }
//                    else if (!isKeyword)
//                    {

//                        //if (isFunctionParameter || isFunctionBody)
//                        //{
//                        //    if (lej_Interpreter_Abstract_List.Last().Value.lej_Interpreter_Abstract_List.ContainsKey(token.TokenStr))
//                        //    {

//                        //    }
//                        //}
//                        //else if (lej_Interpreter_Abstract_List.ContainsKey(token.TokenStr))
//                        //{
//                        //    //lej_Interpreter_Abstract_List[token].keyword = token.TokenStr;
//                        //}
//                        //else
//                        //{
//                            //isFormula
//                            formula += token.TokenStr;
//                        //}


//                    }
//                }
//                else
//                {
//                    //isFormula
//                    formula += token.TokenStr;
//                }
//            }
//            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.is1_Val))
//            {
//                if (isKeyword)
//                {
//                    if (isFunctionParameter || isFunctionBody)
//                    {
//                        if (token.TokenStr.Length > 2 &&
//                            token.TokenStr.StartsWith('\'') && token.TokenStr.EndsWith('\'') &&
//                            token.TokenStr.LastIndexOf('\'') != token.TokenStr.IndexOf('\''))
//                        {

//                            lej_Abstract_FunctionBody_Variables.rightVal += token.TokenStr.Remove(token.TokenStr.Length - 1).Remove(0, 1);
//                            //return Lej_Interpreter_Lexer.TokenType.is1_Val;
//                        }
//                        else
//                        {
//                            lej_Abstract_FunctionBody_Variables.rightVal += token.TokenStr;
//                        }
//                    }
//                    else
//                    {
//                        if (token.TokenStr.Length > 2 &&
//                            token.TokenStr.StartsWith('\'') && token.TokenStr.EndsWith('\'') &&
//                            token.TokenStr.LastIndexOf('\'') != token.TokenStr.IndexOf('\''))
//                        {

//                            lej_Abstract_Variables.rightVal += token.TokenStr.Remove(token.TokenStr.Length - 1).Remove(0, 1);
//                            //return Lej_Interpreter_Lexer.TokenType.is1_Val;
//                        }
//                        else
//                        {
//                            lej_Abstract_Variables.rightVal += token.TokenStr;
//                        }
//                        //lej_Abstract_Variables.rightVal += token.TokenStr;
//                    }
//                }
//                else
//                {
//                    formula += token.TokenStr;
//                }
//            }
//            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.hasR_Val))
//            {
//                if (isKeyword)
//                {
//                    if (isFunctionParameter || isFunctionBody)
//                    {
//                        lej_Abstract_FunctionBody_Variables.rightVal += token.TokenStr;
//                    }
//                    else
//                    {
//                        lej_Abstract_Variables.rightVal += token.TokenStr;
//                    }
//                }
//                else
//                {
//                    formula += token.TokenStr;
//                }
//            }
//            //else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Equal))
//            //{
//            //    if (isKeyword)
//            //    {
//            //        //isKeyword = false;
//            //        //isFunctionParameter = true;
//            //        //lej_Abstract_Variables.isFunction = true;
//            //        isKeyword = false;
//            //    }
//            //}
//            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Comma))
//            {
//                if (isKeyword)
//                {
//                    //isKeyword = false;
//                    //isFunctionParameter = true;
//                    //lej_Abstract_Variables.isFunction = true;
//                    isKeyword = false;
//                }
//            }
//            else if (token.TokenStr.Equals("("))
//            {
//                if (isKeyword)
//                {
//                    //isKeyword = false;
//                    //lej_Abstract_Variables.isFunction = true;
//                    isKeyword = false;
//                }
//                isFunctionParameter = true;
//            }
//            else if (token.TokenStr.Equals(")"))
//            {
//                //if (isKeyword)
//                //{
//                //isKeyword = false;
//                isFunctionParameter = false;
//                lej_Abstract_Variables = new Lej_Interpreter_Abstract();
//                //lej_Abstract.isFunction = true;
//                //}
//            }
//            else if (token.TokenStr.Equals("{"))
//            {
//                isFunctionBody = true;
//            }
//            else if (token.TokenStr.Equals("}"))
//            {
//                isFunctionBody = false;
//                lej_Abstract_FunctionBody_Variables = new Lej_Interpreter_Abstract();
//            }
//            else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.SemiColon))
//            {
//                if (isFunctionParameter || isFunctionBody)
//                {
//                    lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(lej_Abstract_FunctionBody_Variables.keyword, lej_Abstract_FunctionBody_Variables);
//                }
//                else if (!isFunctionParameter && !isFunctionBody)
//                {
//                    lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables.variableName, lej_Abstract_Variables);
//                }
//            }






//            if (token.isNewToken)
//            {
//                isKeyword = false;
//                if ((isFunctionParameter || isFunctionBody) && !string.IsNullOrEmpty(lej_Abstract_FunctionBody_Variables.variableName))
//                {
//                    if (lej_Abstract_Variables.lej_Interpreter_Abstract_List.ContainsKey(lej_Abstract_FunctionBody_Variables.keyword))
//                    {
//                        lej_Abstract_Variables.lej_Interpreter_Abstract_List[lej_Abstract_FunctionBody_Variables.keyword] = lej_Abstract_FunctionBody_Variables;
//                    }
//                    else
//                    {
//                        lej_Abstract_Variables.lej_Interpreter_Abstract_List.Add(lej_Abstract_FunctionBody_Variables.keyword, lej_Abstract_FunctionBody_Variables);
//                    }
//                    lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables.variableName, lej_Abstract_Variables);
//                    lej_Abstract_FunctionBody_Variables = new Lej_Interpreter_Abstract();
//                }

//                if (!isFunctionParameter && !isFunctionBody && !string.IsNullOrEmpty(lej_Abstract_Variables.variableName) && 
//                    !token.isNewTokenStr.Equals("(") && !token.isNewTokenStr.Equals("{"))
//                {

//                        if (lej_Interpreter_Abstract_List.ContainsKey(lej_Abstract_Variables.variableName))
//                        {
//                            lej_Interpreter_Abstract_List[lej_Abstract_Variables.variableName] = lej_Abstract_Variables;
//                        }
//                        else
//                        {
//                            lej_Interpreter_Abstract_List.Add(lej_Abstract_Variables.variableName, lej_Abstract_Variables);
//                        }
//                        lej_Abstract_Variables = new Lej_Interpreter_Abstract();
//                }
//            }
//        }
//    }

//    //reset index
//    index = 0;
//}








//}
//}
