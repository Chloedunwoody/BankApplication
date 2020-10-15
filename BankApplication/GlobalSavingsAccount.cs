using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class GlobalSavingsAccount : Savings, IExchangeable
    {
        public GlobalSavingsAccount(double balance, double interest) : base(balance, interest)
        {
            this.CurrentBalance = balance;
        }


        public double USValue(double rate)
        {
            this.CurrentBalance *= rate;

            return this.CurrentBalance;
        }
    }
}
