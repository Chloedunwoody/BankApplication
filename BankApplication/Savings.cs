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
                CurrentBalance -= amount;
                numOfWithdrawls += 1;
                totalOfWithdrawls += amount;
            }
        }

        public override void MakeDeposit(double amount)
        {
            if ((Stat == Status.inactive) && ((CurrentBalance + amount) > 25))
            {
                Stat = Status.active;
                CurrentBalance += amount; 
                numOfDeposits += 1;
                totalOfDeposits += amount;
            }
            else
            {
                return;
            }
        }

        public override void CalculateInterest()
        {
            monthlyInterestRate = (annualInterestRate / 100) / 12;
            monthlyInterest = (CurrentBalance * monthlyInterestRate) * 100;
            CurrentBalance += monthlyInterest;

        }

        public override string CloseAndReport()
        {
            if (numOfWithdrawls > 4)
            {
                serviceCharge += 1 * numOfWithdrawls;
                CurrentBalance -= serviceCharge;
            }
            else
            {
                CurrentBalance -= serviceCharge;
            }
            CalculateInterest();

            StringBuilder report = new StringBuilder();
            report.AppendLine(String.Format("Previous Blance: {0:C}", StartingBalance));
            report.AppendLine(String.Format("New Balance: {0:C}", CurrentBalance));
            report.AppendLine(String.Format("Service Charge: {0:C}", serviceCharge));
            //How differenciate between pre adding interest currentbalance and post adding interest

            double change = (CurrentBalance - StartingBalance) / CurrentBalance;
            report.AppendLine(String.Format("Percentage of change: {0:P2}", change));
            report.AppendLine(String.Format("Monthly Interest Rate: {0:P2}", monthlyInterestRate));
            report.AppendLine(String.Format("Monthly interest Earned: {0:C}", monthlyInterest));
            report.AppendLine(String.Format("Balance + Interest: {0:C}", CurrentBalance));
            //How differenciate between pre adding interest currentbalance and post adding interest

            numOfDeposits = 0;
            numOfWithdrawls = 0;
            serviceCharge = 0;

            return report.ToString();
        }
        //balance below 25 = inactive not done yet
    

    }
}
