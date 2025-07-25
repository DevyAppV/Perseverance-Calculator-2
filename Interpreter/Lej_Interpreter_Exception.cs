using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance_Calculator_2.Interpreter
{
    public class Lej_Interpreter_Exception : Exception
    {
        public Lej_Interpreter_Exception() { }
        public Lej_Interpreter_Exception(string message) : base(message)
        {

        
        }

        //public override string ToString()
        //{
        //    return Message;
        //}
    }
}
