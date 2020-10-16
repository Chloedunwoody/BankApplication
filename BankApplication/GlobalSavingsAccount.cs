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
            base.MakeDeposit(amount);
        }

        public override void MakeWithdrawl(double amount)
        {
            base.MakeWithdrawl(amount);
        }
        public double MonthlyInterestRate => annualInterestRate / 12;
        public override void CalculateInterest()
        {
            monthlyInterestTotal = MonthlyInterestRate * this.CurrentBalance;
            this.CurrentBalance += monthlyInterestTotal;
        }
        public override string CloseAndReport()
        {
            int serviceCharge = 0;
            while (numOfWithdrawls > 4)
            {
                serviceCharge += 1;
                numOfWithdrawls -= 1;
            }

            this.CurrentBalance -= serviceCharge;
            CalculateInterest();

            numOfDeposits = 0;
            numOfWithdrawls = 0;
            serviceCharge = 0;

            StringBuilder report = new StringBuilder();
            report.AppendLine("Previous Blance: " + this.StartingBalance);
            report.AppendLine("New Balance: " + this.CurrentBalance);

            double change = ((this.CurrentBalance - this.StartingBalance) / this.StartingBalance) * 100;
            report.AppendLine("Percentage of change: " + change);

            //Calculate interest details, maybe use ToSTRING??
            report.AppendLine("Monthly interest Rate: " + this.MonthlyInterestRate);
            report.AppendLine("Monthly interest Earned: " + this.monthlyInterestTotal);
            report.AppendLine("Balance + Interest: " + this.CurrentBalance);

            return report.ToString();
        }
    
        public double USValue(double rate)
        {
            this.CurrentBalance *= rate;

            return this.CurrentBalance;
        }
    }
}
