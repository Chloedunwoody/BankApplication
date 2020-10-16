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
        public override void MakeDeposit(double amount)
        {
            this.CurrentBalance += amount; //depends on if set method is allowed
            numOfDeposits += 1;
            totalOfDeposits += amount;
        }

        public override void MakeWithdrawl(double amount)
        {
            this.CurrentBalance += amount;
            numOfDeposits += 1;
            totalOfDeposits += amount;
        }


        public double USValue(double rate)
        {
            this.CurrentBalance *= rate;

            return this.CurrentBalance;
        }
    }
}
