using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    internal class AccountNotFoundException : SystemException
    {
        private string accNum;

        public AccountNotFoundException(string accNum)
        {
            this.accNum = accNum;
        }

        public override string ToString()
        {
            return "Account with account number of " + accNum + " cannot be found";
        }
    }
}
