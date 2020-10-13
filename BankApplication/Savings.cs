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
        public override void MakeWithdrawl(double amount)
        {

        }

        public override void MakeDeposit(double amount)
        {

        }

        public override string CloseAndRepport()
        {

            return base.CloseAndRepport();

        }
    }
}
