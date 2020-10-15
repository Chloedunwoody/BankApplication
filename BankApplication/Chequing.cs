using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Chequing : Account
    {

        public Chequing(double balance, double interest): base(balance, interest)
        {
            this.CurrentBalance = CurrentBalance;
        }
        public override void MakeWithdrawl(double amount)
        {
            if ((this.CurrentBalance - amount) < 0)
            {
                this.CurrentBalance -= 15;
                Console.WriteLine("Refused! Insucifient Funds");
            }
            else
                base.MakeWithdrawl(amount);
        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount); 
            //might not need to declare the method ??
        }

        //Monthlyinterest property
        public double MonthlyInterestRate => annualInterestRate / 12;
        public override void CalculateInterest()
        {
            monthlyInterestTotal = MonthlyInterestRate * this.CurrentBalance;
            this.CurrentBalance += monthlyInterestTotal;
        }

        public override string CloseAndReport()
        {
            this.serviceCharge += 5;
            this.serviceCharge += (0.10 * numOfWithdrawls);

            this.CurrentBalance -= serviceCharge;
            CalculateInterest();

            numOfDeposits = 0; //verify if possible to = 0
            numOfWithdrawls = 0;
            serviceCharge = 0;

            StringBuilder report = new StringBuilder();
            report.Append("Previous Blance: " + this.StartingBalance);
            report.AppendLine("New Balance: " + this.CurrentBalance);

            double change = (this.StartingBalance * this.CurrentBalance) * 100;
            report.AppendLine("Percentage of change: " + change);

            //Calculate interest details, maybe use ToSTRING??
            report.AppendLine("Monthly interest Rate: " + MonthlyInterestRate);
            report.AppendLine("Monthly interest Earned: " + monthlyInterestTotal);
            report.AppendLine("Balance + Interest: " + this.CurrentBalance);

            return report.ToString();
        }

        
    }
}
