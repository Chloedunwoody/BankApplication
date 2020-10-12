using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class GlobalSavingsAccount : Savings, IExchangeable
    {
        
        public double USValue(double rate)
        {
            _currentBalance *= rate;

            return _currentBalance;
        }
    }
}
