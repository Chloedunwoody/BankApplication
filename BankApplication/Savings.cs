﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Savings : Account, IAccount
    {
        public Savings(double balance, double interest) : base(balance, interest)
        {
            //unsure about this constructor generated by visual studio
        }
    }
}
