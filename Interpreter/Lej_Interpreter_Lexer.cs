using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Interpreter
{
    public class Lej_Interpreter_Lexer
    {

        public enum TokenType
        {
            Variable,//or formula
            //hasLR_Val,
            //hasBool_Val,
            //hasR_Val,
            //is1_Val,
            StringQuote,
            Value,
            Equal,
            Math,
            //Public,
            //Relational_Operator,
            //Logical_Operator,
            //Math,
            //Number,
            Loop,
            Boolean,
            ComparisonOperator,
            Conditional,
            SemiColon,
            Comma,
            Parenthesis_Open,
            Parenthesis_Close,
            CurlyBraces_Open,
            CurlyBraces_Close,
            Bracket_Open,
            Bracket_Close,
            //void, string, double, bool
            //Keyword,
            //Return,
            //Boolean,
            //Conditional,
            //Keyword
        }

        public static Dictionary<string, string> Token = new Dictionary<string, string>()
        {

            //equal
            {"=","="},

            //Comparison Op
            {"==","=="},
            {">",">"},
            {">=",">="},
            {"<","<"},
            {"<=","<="},
            {"!","!"},
            {"!=","!="},

            //logical op RLVal
            {"&&","&&"},
            {"||","||"},

            //math RVal
            {"-","-"},
            {"+","+"},
            {"/","/"},
            {"*","*"},
            {"%","%"},

            {"-=","-="},
            {"+=","+="},
            {"/=","/="},
            {"*=","*="},
            {"%=","%="},

            //separator
            {",",","},

            //end declaration
            {";",";"},


            //string
            {"'","'"},


            //parenthesis
            {"(","("},
            {")",")"},
            {"{","{"},
            {"}","}"},
            {"]","]"},
            {"[","["},
            
            //boolean
            {"true","true"},
            {"false","false"},


            //conditional
            {"if","if"},
            {"elseif","elseif"},
            {"else","else"},

            //loops
            {"while","while" },
            {"foreach","foreach" },

            //keyword
            //{"public","public" }
            
            //{"void","void"},
            //{"return","return"},
            //{"string","string"},
            //{"double","double"},
            //{"bool","bool"},
        };



        public static (string TokenStr,bool isNewToken, string isNewToken_Str) getLexerToken(string strLexer, ref int index)
        {

            string currentCharStr = "";
            string prevCharStr = "";
            //bool containsOperator = false;
            bool containsOperator = false;
            string strToReturn = "";
            bool isNewToken = false;
            string isNewTokenStr = "";
            //bool isElse = false;

            for (; index < strLexer.Length; index++)
            {
                if(strLexer[index].Equals('\r') ||
                    strLexer[index].Equals('\n'))
                {
                    continue;
                }

                if ((getIsNewToken(strLexer, index) || strLexer[index].Equals(' '))&&
                    !currentCharStr.Equals(""))
                {
                    isNewTokenStr = strLexer[index].ToString();
                    strToReturn = currentCharStr;
                    if (strLexer[index].Equals(' '))
                    {
                        isNewToken = false;
                    }
                    else
                    {
                        //index--; 
                        isNewToken = true; 
                    }

                    //if (strLexer[index].Equals('{')||
                    //    strLexer[index].Equals('}') ||
                    //    strLexer[index].Equals('(') ||
                    //    strLexer[index].Equals(')'))
                    //{
                    //    index--;
                    //}
                    break;
                }
                currentCharStr += strLexer[index].ToString();
                if ((currentCharStr.Equals(" ") || getIsNewToken(strLexer, index)))
                {
                    if (!currentCharStr.Equals(" "))
                    {
                        isNewTokenStr = strLexer[index].ToString();
                        isNewToken = true;
                        return (Lej_Interpreter_Lexer.Token[currentCharStr], isNewToken, isNewTokenStr);
                    }
                    currentCharStr = "";
                    continue;
                }

                if (Lej_Interpreter_Lexer.Token.ContainsKey(currentCharStr))
                {
                    if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("=") ||
                        (containsOperator && strLexer[index].Equals('=')))
                    {
                        if (containsOperator)
                        {
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                            //containsOperator = false;
                            return (Lej_Interpreter_Lexer.Token[currentCharStr], isNewToken, isNewTokenStr);
                        }
                        if(containsOperator) 
                            return (Lej_Interpreter_Lexer.Token[prevCharStr], isNewToken, isNewTokenStr);
                        else
                            containsOperator = true;
                    }
                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals(">"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }
                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("<"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }
                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("!"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }


                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("&&"))
                    {
                        //if (containsOperator)
                            strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        //containsOperator = true;
                    }
                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("||"))
                    {
                        //if (containsOperator)
                            strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        //containsOperator = true;
                    }



                    //=====================================

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("-"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                        //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("+"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("/"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("*"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("%"))
                    {
                        //if (containsOperator)
                            //strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                        containsOperator = true;
                    }













                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals(","))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];

                    //}

                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals(";"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("'"))
                    {
                        while (index+1 < strLexer.Length)
                        {
                            index++;
                            currentCharStr += strLexer[index];
                            if (strLexer[index].Equals('\''))
                            {
                                break;
                            }
                        }
                        strToReturn = currentCharStr;
                        //return (currentCharStr, isNewToken, isNewTokenStr);

                    }










                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("("))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}

                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals(")"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}

                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("{"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}

                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("}"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}















                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("while"))
                    {
                        strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }


                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("foreach"))
                    {
                        strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }


                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("true"))
                    {
                        strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("false"))
                    {
                        strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("if"))
                    {
                        strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    }

                    else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("else"))
                    {
                        if (index + 3< strLexer.Length)
                        {
                            string currentCharStr_ElseIf = currentCharStr;
                            currentCharStr_ElseIf += strLexer[index + 1].ToString();
                            currentCharStr_ElseIf += strLexer[index + 2].ToString();
                            currentCharStr_ElseIf += strLexer[index + 3].ToString();
                            if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("elseif"))
                            {
                                if (getIsNewToken(strLexer, index + 1))
                                {
                                    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr_ElseIf];
                                    //return (Lej_Interpreter_Lexer.Token[currentCharStr_ElseIf], isNewToken, isNewTokenStr);
                                }
                            }
                            else if (getIsNewToken(strLexer, index + 1))
                            {
                                strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                                //return (Lej_Interpreter_Lexer.Token[currentCharStr], isNewToken, isNewTokenStr);
                            }


                        }
                        else if (strLexer.Length >= index + 1)
                        {
                            if (getIsNewToken(strLexer, index + 1))
                            {
                                strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                                //isNewTokenStr = strLexer[index+1].ToString();
                                //return (Lej_Interpreter_Lexer.Token[currentCharStr], isNewToken, isNewTokenStr);
                            }
                        }
                    }









                    ////////////////////else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("public"))
                    ////////////////////{
                    ////////////////////    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    ////////////////////}


                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("void"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}


                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("return"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}


                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("string"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}


                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("double"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}


                    //else if (Lej_Interpreter_Lexer.Token[currentCharStr].Equals("bool"))
                    //{
                    //    strToReturn = Lej_Interpreter_Lexer.Token[currentCharStr];
                    //}
                    ////else if (currentCharStr.Equals(" "))
                    ////{
                    ////    currentCharStr = "";
                    ////}
                    //else
                    //{
                    //    if (containsOperator)
                    //        strToReturn = Lej_Interpreter_Lexer.Token[prevCharStr];
                    //}
                }
                else if (Lej_Interpreter_Lexer.Token.ContainsKey(strLexer[index].ToString()))
                {
                    index--;
                    return (currentCharStr.Remove(currentCharStr.Length-1), false, "");
                }
                //else if (Lej_Interpreter_Lexer.Token.ContainsKey(currentCharStr))
                //{
                //    index--;
                //    return (currentCharStr.Remove(currentCharStr.Length-1), false, "");
                //}
                //if (containsOperator)
                //    prevCharStr += strLexer[index].ToString();
                if (containsOperator)
                {
                    if (prevCharStr.Length == 1)
                    {
                        index--;
                        return (prevCharStr, isNewToken, isNewTokenStr);
                    }
                    prevCharStr += strLexer[index].ToString();
                }
            }


            if(index >= strLexer.Length)
            {
                strToReturn = currentCharStr;
            }
            return (strToReturn, isNewToken, isNewTokenStr);
        }

        private static bool getIsNewToken(string str, int index)
        {
            if (index > str.Length-1) return true;

            //if (str[index].Equals(' '))
            //{
            //    return true;
            //}
            if (str[index].Equals('('))
            {
                return true;
            }
            if (str[index].Equals(')'))
            {
                return true;
            }
            if (str[index].Equals('{'))
            {
                return true;
            }
            if (str[index].Equals('}'))
            {
                return true;
            }
            if (str[index].Equals(','))
            {
                return true;
            }
            if (str[index].Equals(';'))
            {
                return true;
            }
            return false;
        }
    }
}
