using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public static class Helper
    {
        public static double GetPercentageChange(double CurrentBalance, double StartingBalance)
        {
            //To revist
            double change = (CurrentBalance - StartingBalance) / CurrentBalance;

            return change;
        }

        public static string ToNAMoneyFormat(bool round, double amount)
        {
            //implement -12.4 becomes (12.40)
            if(round == false)
            {
                return amount.ToString();
            }
            else
                Math.Round(amount, 2);
                return amount.ToString();
        }

    }
}
