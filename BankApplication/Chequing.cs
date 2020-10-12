using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Chequing : Account
    {
        public override void makeWithdrawl(double amount)
        {
            
            base.MakeWithdrawl(amount);

        }

        public void makeDeposit()
        {
            base.MakeDeposit();
        }

        public override void closeAndRepport()
        {

        }
    }
}
