using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Interpreter
{
    public class Lej_Interpreter_Parser
    {


        public static Lej_Interpreter_Lexer.TokenType? parseGetLexerToken(ref string tokenValue) {

            if (Lej_Interpreter_Lexer.Token.ContainsKey(tokenValue))
            {
                switch (Lej_Interpreter_Lexer.Token[tokenValue])
                {
                    case "=":
                        return Lej_Interpreter_Lexer.TokenType.Equal;


                    case "==":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case ">":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case ">=":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case "<":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case "<=":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case "!":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case "!=":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;





                    case "&&":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;

                    case "||":
                        return Lej_Interpreter_Lexer.TokenType.ComparisonOperator;








                    case "-":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "+":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "/":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "*":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "%":
                        return Lej_Interpreter_Lexer.TokenType.Math;



                    case "-=":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "+=":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "/=":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "*=":
                        return Lej_Interpreter_Lexer.TokenType.Math;

                    case "%=":
                        return Lej_Interpreter_Lexer.TokenType.Math;









                    case ",":
                        return Lej_Interpreter_Lexer.TokenType.Comma;

                    case ";":
                        return Lej_Interpreter_Lexer.TokenType.SemiColon;







                    case "'":
                        return Lej_Interpreter_Lexer.TokenType.StringQuote;













                    case "(":
                        return Lej_Interpreter_Lexer.TokenType.Parenthesis_Open;

                    case ")":
                        return Lej_Interpreter_Lexer.TokenType.Parenthesis_Close;

                    case "{":
                        return Lej_Interpreter_Lexer.TokenType.CurlyBraces_Open;

                    case "}":
                        return Lej_Interpreter_Lexer.TokenType.CurlyBraces_Close;

                    case "[":
                        return Lej_Interpreter_Lexer.TokenType.Bracket_Open;

                    case "]":
                        return Lej_Interpreter_Lexer.TokenType.Bracket_Close;















                    case "true":
                        return Lej_Interpreter_Lexer.TokenType.Boolean;

                    case "false":
                        return Lej_Interpreter_Lexer.TokenType.Boolean;




                    case "if":
                        return Lej_Interpreter_Lexer.TokenType.Conditional;

                    case "elseif":
                        return Lej_Interpreter_Lexer.TokenType.Conditional;

                    case "else":
                        return Lej_Interpreter_Lexer.TokenType.Conditional;






                    case "while":
                        return Lej_Interpreter_Lexer.TokenType.Loop;
                    case "foreach":
                        return Lej_Interpreter_Lexer.TokenType.Loop;



                    //case "public":
                    //    return Lej_Interpreter_Lexer.TokenType.Public;


                    //case "void":
                    //    return Lej_Interpreter_Lexer.TokenType.Keyword;

                    //case "return":
                    //    return Lej_Interpreter_Lexer.TokenType.Return;

                    //case "string":
                    //    return Lej_Interpreter_Lexer.TokenType.Keyword;

                    //case "double":
                    //    return Lej_Interpreter_Lexer.TokenType.Keyword;

                    //case "bool":
                    //    return Lej_Interpreter_Lexer.TokenType.Keyword;

                    default:
                        return null;
                }
            }
            else
            {
                double result = double.NaN;
                //is num
                if (double.TryParse(tokenValue, out result))
                {
                    return Lej_Interpreter_Lexer.TokenType.Value;

                }
                //is string
                else if(tokenValue.Length > 2 && 
                    tokenValue.StartsWith('\'') && tokenValue.EndsWith('\'')&&
                    tokenValue.LastIndexOf('\'') != tokenValue.IndexOf('\''))
                {
                    
                    //tokenValue = tokenValue.Remove(tokenValue.Length-1).Remove(0,1);
                    return Lej_Interpreter_Lexer.TokenType.Value;
                }
                //is var or math
                else
                {
                    return Lej_Interpreter_Lexer.TokenType.Variable;
                }
            }



        }





    }
}
