using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    public sealed class InvalidAmountException : SystemException
    {
        double amount;
        public InvalidAmountException(double amount)
        {
            this.amount = amount;
        }

        public override string ToString()
        {
            return "Invalid Amount: " + amount;
        }
    }
}
