using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Interpreter
{

    public class Lej_Interpreter_Abstract
    {
        //public bool isFunction = false;
        //public string keyword = "";
        public string variableName = "";
        public string value = "";
        public string isContainedWithin_FunctionName = "";
        //public bool isPublicVar=false;
        public bool isVariable=false;
        public bool isDouble=false;
        public bool isBoolean=false;
        public bool isString=false;

        //public string leftVal = "";
        //public string rightVal = "";

        public Dictionary<string, Lej_Interpreter_Abstract> lej_Interpreter_Abstract_Dictionary = new Dictionary<string, Lej_Interpreter_Abstract>();
        public List<Lej_Interpreter_Abstract> lej_Interpreter_Abstract_List = new List<Lej_Interpreter_Abstract>();


        public Lej_Interpreter_Abstract() { }
        //tokenKeyword var = val;
        //public Lej_Interpreter_Abstract(Lej_Interpreter_Lexer.TokenType tokenType)
        //{

        //    if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Variable))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.hasLR_Val))
        //    {

        //    }
            

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.hasLR_Val))
        //    {

        //    }
            

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.is1_Val))
        //    {

        //    }
            
            

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.StringQuote))
        //    {

        //    }
            

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Equal))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Keyword))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Comma))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.SemiColon))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Parenthesis_Open))
        //    {

        //    }
            

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Parenthesis_Close))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.CurlyBraces_Open))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.CurlyBraces_Close))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Keyword))
        //    {

        //    }

        //    else if (tokenType.Equals(Lej_Interpreter_Lexer.TokenType.Return))
        //    {

        //    }

        //    else
        //    {
        //        //variable
        //    }

        //}


    }
}
