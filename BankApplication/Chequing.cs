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
            if ((CurrentBalance - amount) < 0)
            {
                CurrentBalance -= 15;
                Console.WriteLine("Refused! Insucifient Funds. Service Charge 15$ applied");
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
            CurrentBalance += amount; 
            numOfDeposits += 1;
            totalOfDeposits += amount;
        }

        

        public override void CalculateInterest()
        {
            monthlyInterestRate = (annualInterestRate/100) / 12;
            monthlyInterest = (CurrentBalance * monthlyInterestRate)*100;
            CurrentBalance += monthlyInterest;

        }

        public override string CloseAndReport()
        {
            serviceCharge += 5;
            serviceCharge += 0.10 * numOfWithdrawls;

            CurrentBalance -= serviceCharge;
            

            StringBuilder report = new StringBuilder();
            report.AppendLine(String.Format("Previous Blance: {0:C}",StartingBalance));
            report.AppendLine(String.Format("New Balance: {0:C}",CurrentBalance));
            report.AppendLine(String.Format("Service Charge: {0:C}", serviceCharge));
            
            
            
            report.AppendLine(String.Format("Percentage of change: {0:P2}", Extension.GetPercentageChange(CurrentBalance, StartingBalance)));
            CalculateInterest();
            report.AppendLine(String.Format("Monthly Interest Rate: {0:P2}", monthlyInterestRate));
            report.AppendLine(String.Format("Monthly interest Earned: {0:C}", monthlyInterest));
            report.AppendLine(String.Format("Balance + Interest: {0:C}", CurrentBalance));
            

            numOfDeposits = 0;
            numOfWithdrawls = 0;
            serviceCharge = 0;

            return report.ToString();
        }

        
    }
}
