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
            {
                this.CurrentBalance -= amount;
                numOfWithdrawls += 1;
                totalOfWithdrawls += amount;
            }
        }

        public override void MakeDeposit(double amount)
        {
            this.CurrentBalance += amount; 
            numOfDeposits += 1;
            totalOfDeposits += amount;
        }

        //Monthlyinterest property
        public double MonthlyInterestRate => annualInterestRate / 12;
        public override void CalculateInterest()
        {
            //TO REVISIT
            var monthlyInterestRate = (this.annualInterestRate / 12);
            var monthlyInterest = this.CurrentBalance * monthlyInterestRate;
            this.CurrentBalance += monthlyInterest;
            monthlyInterestTotal = MonthlyInterestRate * this.CurrentBalance;
            this.CurrentBalance += monthlyInterestTotal;
        }

        public override string CloseAndReport()
        {
            this.serviceCharge += 5;
            this.serviceCharge += (0.10 * numOfWithdrawls);

            this.CurrentBalance -= serviceCharge;
            CalculateInterest();

            numOfDeposits = 0;
            numOfWithdrawls = 0;
            serviceCharge = 0;

            StringBuilder report = new StringBuilder();
            report.AppendLine("Previous Blance: " + this.StartingBalance);
            report.AppendLine("New Balance: " + this.CurrentBalance);

            double change = ((this.CurrentBalance - this.StartingBalance)/this.StartingBalance) *100;
            report.AppendLine("Percentage of change: " + change);

            //Calculate interest details, maybe use ToSTRING??
            report.AppendLine("Monthly interest Rate: " + this.MonthlyInterestRate);
            report.AppendLine("Monthly interest Earned: " + this.monthlyInterestTotal);
            report.AppendLine("Balance + Interest: " + this.CurrentBalance);

            return report.ToString();
        }

        
    }
}
