using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class ChoiceException : Exception
    {
        public ChoiceException(string msg) : base(msg)
        { 
            
        }
    }
}
