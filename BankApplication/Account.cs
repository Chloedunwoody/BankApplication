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

        protected Status stat { set; get; }

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

        public Account(double balance, double interest)
        {
            this.StartingBalance = balance;
            this.CurrentBalance = balance;
            this.annualInterestRate = interest;

        }

        public virtual void MakeDeposit(double amount) 
        {
            this.CurrentBalance += amount; //depends on if set method is allowed
            numOfDeposits += 1;
            totalOfDeposits += amount;
        }

        public virtual void MakeWithdrawl(double amount)
        {
            this.CurrentBalance -= amount; //depends on if set method is allowed
            numOfWithdrawls += 1;
            totalOfWithdrawls += amount;
        }

        public virtual void CalculateInterest()
        {
            var monthlyInterestRate = (this.annualInterestRate / 12);
            var monthlyInterest = this.CurrentBalance * monthlyInterestRate;
            this.CurrentBalance += monthlyInterest;
            //to revisit
        }

        public abstract string CloseAndReport();
    }


    
}
