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
        public override void MakeDeposit(double amount) => base.MakeDeposit(amount);

        public override void MakeWithdrawl(double amount) => base.MakeWithdrawl(amount);

        public override void CalculateInterest() => base.CalculateInterest();

        public override string CloseAndReport() => base.CloseAndReport();

        public double USValue(double rate)
        {
            CurrentBalance *= rate;

            return CurrentBalance;
        }
    }
}
