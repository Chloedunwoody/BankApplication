using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Chequing : Account
    { 
        public void makeWithdrawl(double amount)
        {
            double result;
            double serviceCharge = 15;

            result = _currentBalance - amount;

            if (result < 0)
            {
                _currentBalance -= serviceCharge;
            }
            else
                _currentBalance -= amount;
        }

            public void makeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }

        public string closeAndRepport()
        {
            return base.CloseAndRepport();
        }

        
    }
}
