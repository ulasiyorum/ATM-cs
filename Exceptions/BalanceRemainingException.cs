using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    internal class BalanceRemainingException : SystemException
    {
        private double balance;

        public BalanceRemainingException(double balance)
        {
            this.balance = balance;
        }

        public override string ToString()
        {
            return "Account you are trying to close still has " + balance + "TL. Transfer your funds to another account" +
                " before trying to close it";
        }
    }
}
