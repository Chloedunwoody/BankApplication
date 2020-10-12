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
        public double _startingBalance { get; }
        public double _currentBalance { set;  get; } //check if allowed to use set method

        double totalOfDeposits;
        int numOfDeposits;
        double totalOfWithdrawls;
        int numOfWithdrawls;
        double annualInterestRate;
        double serviceCharge;
        private double monthlyInterestTotal;

        enum status
        { 
            active,
            inactive
        }

        public Account(double balance, double interest)
        {
            _startingBalance = balance; 
            annualInterestRate = interest;
        }

        //Monthlyinterest property
        public double MonthlyInterestRate => annualInterestRate / 12; 

        public void CalculateInterest()
        {
            monthlyInterestTotal = MonthlyInterestRate * _currentBalance;
            _currentBalance += monthlyInterestTotal;
        }

        public void CloseAndRepport()
        {
            _currentBalance -= serviceCharge;
            CalculateInterest();
            numOfDeposits = 0; //verify if possible to = 0
            numOfWithdrawls = 0;
            serviceCharge = 0;

           //TODO Display previous balance and new balance after ^
           //percentage change from starting and current balances

            //consolewrite calculate interest
        }

        public void MakeDeposit(double amount)
        {
            _currentBalance += amount; //depends on if set method is allowed
            numOfDeposits += 1;

        }

        public void MakeWithdrawl(double amount)
        {
            _currentBalance -= amount; //depends on if set method is allowed
            numOfWithdrawls += 1;
        }
    }
}
