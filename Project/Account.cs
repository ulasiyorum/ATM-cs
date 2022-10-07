using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Exceptions;

namespace ATM.Project
{
    internal class Account
    {
        private string accNum;
        private double balance;
        private static List<string> accNums = new();
        internal Account()
        {
            do
            {
                Random random = new Random();
                accNum = "" + random.Next(10) + "" + random.Next(10) + "" + random.Next(10) + "" + random.Next(10) + "" + random.Next(10);
                balance = 0;
                foreach (string acc in accNums)
                {
                    if (acc == accNum) { accNum = null; break; }
                }
            } while (accNum == null);
        }
        internal Account(string accNum)
        {
            do
            {
                Random random = new Random();
                accNum = accNum.Length > 5 ? accNum.Substring(0, 5) : (accNum.Length < 5 || accNum == null) ? ""
                    + random.Next(10) + "" + random.Next(10) + "" + random.Next(10) + "" + random.Next(10)
                    + "" + random.Next(10) : accNum;
                balance = 0;
                foreach (string acc in accNums)
                {
                    if (acc == accNum) { accNum = null; break; }
                }
            } while (accNum == null);
        }
        internal Account(string accNum, double balance)
        {
            do
            {
                Random random = new Random();
                balance = balance < 0 ? 0 : balance;
                accNum = accNum.Length > 5 ? accNum.Substring(0, 5) : (accNum.Length < 5 || accNum == null) ? ""
                    + random.Next(10) + "" + random.Next(10) + "" + random.Next(10) + "" + random.Next(10)
                    + "" + random.Next(10) : accNum;
                foreach (string acc in accNums)
                {
                    if(acc == accNum) { accNum = null; break; }
                }
                this.accNum = accNum;
                this.balance = balance;
            } while(accNum == null);
        }
        public string AccNum { get => accNum; }
        public double Balance { get => balance; }

        public void Deposit(double amount)
        {
            if (amount < 0) { throw new InvalidAmountException(amount); } 
            else { balance += amount; }
        }
        public void Withdraw(double amount)
        {
            if(amount < 0 || amount > balance) { throw new InvalidAmountException(amount); }
            else
            {
                balance -= amount;
            }
        }
        public override string ToString()
        {
            return "Account Number of " + accNum + " has " + balance + "TL in their account.";
        }
    }
}
