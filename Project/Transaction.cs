using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Exceptions;

namespace ATM.Project
{
    internal class Transaction
    {
        private int type;
        private string from;
        private string to;
        private double amount;

        public int Type { get => type; }
        public double Amount { get => amount; }
        public string From { get => from; }
        public string To { get => to; }
        public Transaction(int type, string from, string to, double amount)
        {
            if ((type != 1 && type != 2 && type != 3) || amount < 0) { throw new InvalidParameterException("Invalid transaction."); }
            else
            {
                this.type = type;
                this.from = from;
                this.to = to;
                this.amount = amount;
            }
        }
        public Transaction(int type, string only, double amount)
        {
            if ((type != 1 && type != 2 && type != 3) || amount < 0) { throw new InvalidParameterException("Invalid transaction."); }
            else
            {
                if (type == 1 || type == 2) { to = only; }
                else { from = only; }
                this.type = type;
                this.amount = amount;
            }
        }

        public override string ToString()
        {
            if(type == 1)
            {
                return "Deposit \nAccount Number:" + to + "\nAmount:" + amount;
            }
            else if(type == 2)
            {
                return "Transaction \nAccount Number From:" + from + "\nTo:" + to + "\nAmount:" + amount;
            }
            else
            {
                return "Withdraw \nAccount Number:" + from + "\n Amount:" + amount; 
            }
        }

        public class TransactionComparator : Comparer<Transaction>
        {
            public override int Compare(Transaction x, Transaction y)
            {
                if(x.type - y.type != 0)
                {
                    return x.type - y.type;
                } else
                {
                    if(x.type == 1 || x.type == 2) { return int.Parse(x.to) - int.Parse(y.to); }
                    else { return int.Parse(x.from) - int.Parse(y.from); }
                }
            }
        }
    }
}
