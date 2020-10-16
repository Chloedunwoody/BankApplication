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
        //will figure out the visibility later on. !!!!
        public double StartingBalance { get; }
        protected internal double CurrentBalance { set; get; }

        protected Status Stat { set; get; }

        protected double totalOfDeposits;
        protected int numOfDeposits =0;
        protected double totalOfWithdrawls;
        protected int numOfWithdrawls =0;
        protected double annualInterestRate;
        protected double serviceCharge;
        protected double monthlyInterestTotal;

        protected enum Status
        {
            inactive,
            active
        }

        protected Account(double balance, double interest)
        {
            this.StartingBalance = balance;
            this.CurrentBalance = balance;
            this.annualInterestRate = interest;

        }

        public abstract void MakeDeposit(double amount);
        public abstract void MakeWithdrawl(double amount);
        public abstract void CalculateInterest();
        public abstract string CloseAndReport();
    }


    
}
