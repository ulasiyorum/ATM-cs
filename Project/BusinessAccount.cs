using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Project
{
    internal class BusinessAccount : Account
    {
        private double interestRate;
        public double InterestRate { get => interestRate; }

        internal BusinessAccount(string accNum, double interestRate) : base(accNum)
        {
            this.interestRate = interestRate;
        }
        internal BusinessAccount(double interestRate, string accNum, double balance) : base(accNum,balance)
        {
            this.interestRate = interestRate > 0 ? interestRate : 0;
        }
        public double CalculateInterest() { return interestRate * Balance; }
    }
}
