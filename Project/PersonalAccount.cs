using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM.Project
{
    internal class PersonalAccount : Account
    {
        private string name;
        private string surname;
        private string pin;

        public string Name { get => name; }
        public string Surname { get => surname; }
        public string PIN { get => pin; }

        internal PersonalAccount(string name, string surname, string pin) : base()
        {
            this.name = name;
            this.surname = surname;
            this.pin = pin;
        }
        internal PersonalAccount(string accNum, string name, string surname, string pin) : base(accNum)
        {
            this.name = name;
            this.surname = surname;
            this.pin = pin;
        }
        internal PersonalAccount(string accNum, string name, string surname, double balance) : base(accNum,balance)
        {
            this.name = name;
            this.surname = surname;
            pin = "0000";
        }

        public override string ToString()
        {
            return "Account Number of " + AccNum + " belonging to " + name + " " + surname.ToUpper() + " has " + Balance + "TL in their account.";
        }
    }
}
