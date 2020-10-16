using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Savings : Account
    {
        public Savings(double balance, double interest) : base(balance, interest)
        {
            if (balance < 25)
            {
                Stat = Status.inactive;
            }
            else
                Stat = Status.active;

            this.CurrentBalance = balance;
        }

        public override void MakeWithdrawl(double amount)
        {
            if (Stat == Status.inactive)
            {
                Console.WriteLine("Invalid Entry Account is Inactive");
                //throw exception
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
            if ((Stat == Status.inactive) && ((CurrentBalance + amount) > 25))
            {
                this.Stat = Status.active;
                this.CurrentBalance += amount; 
                numOfDeposits += 1;
                totalOfDeposits += amount;
            }
            else
            {
                return;
            }
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

            numOfDeposits = 0; //verify if possible to = 0
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
        //balance below 25 = inactive not done yet
    }
}
