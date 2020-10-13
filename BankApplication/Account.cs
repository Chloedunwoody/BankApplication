using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    abstract class Account : IAccount
    {
        //will figure out the visibility later on.
        public double _startingBalance { set; get; }
        public double _currentBalance { set; get; }

        double totalOfDeposits;
        int numOfDeposits;
        double totalOfWithdrawls;
        int numOfWithdrawls;
        double annualInterestRate;
        double serviceCharge;
        private double monthlyInterestTotal;

        public enum status
        { 
            inactive,
            active
        }


        //Methods

        public Account(double balance, double interest)
        {
            _startingBalance = balance;
            _currentBalance = balance;
            annualInterestRate = interest;
        }

        public virtual  void MakeWithdrawl(double amount)
        {
            _currentBalance -= amount; //depends on if set method is allowed
            numOfWithdrawls += 1;
        }        

        public virtual void MakeDeposit(double amount)
        {
            _currentBalance += amount; //depends on if set method is allowed
            numOfDeposits += 1;

        }

        //Monthlyinterest property
        public double MonthlyInterestRate => annualInterestRate / 12;
        public virtual void CalculateInterest()
        {
            monthlyInterestTotal = MonthlyInterestRate * _currentBalance;
            _currentBalance += monthlyInterestTotal;
        }

        public virtual string CloseAndRepport()
        {
            _currentBalance -= serviceCharge;
            CalculateInterest();

            numOfDeposits = 0; //verify if possible to = 0
            numOfWithdrawls = 0;
            serviceCharge = 0;

            StringBuilder report = new StringBuilder();
            report.Append("Previous Blance: " + _startingBalance);
            report.AppendLine("New Balance: " + _currentBalance);

            double change = (_startingBalance * _currentBalance) * 100;
            report.AppendLine("Percentage of change: " + change);

            //Calculate interest details, maybe use ToSTRING??
            report.AppendLine("Monthly interest Rate: " + MonthlyInterestRate);
            report.AppendLine("Monthly interest Earned: " + monthlyInterestTotal );
            report.AppendLine("Balance + Interest: " + _currentBalance);

            return report.ToString();

       
        }


    }
}
