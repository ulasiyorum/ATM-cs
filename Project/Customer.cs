using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Exceptions;

namespace ATM.Project
{
    internal class Customer
    {
        private string name;
        private string surname;
        private int id;
        private List<PersonalAccount> personalAccounts = new();
        private static List<Customer> customers = new();

        internal Customer(int id,string name,string surname)
        {
            Random random = new Random();
            do
            {
                this.id = id > 0 && id.ToString().Length == 4 ? id : random.Next(1000, 9999); ;
                foreach(Customer c in customers)
                {
                    if(c.id == this.id) { this.id = 0; }
                }
                this.name = name;
                this.surname = surname;
            } while (this.id == 0);
            
        }

        internal void OpenAccount(string accNum)
        {
            personalAccounts.Add(new PersonalAccount(accNum,name,surname,0));
        }
        internal void OpenAccount(string accNum, string pin)
        {
            personalAccounts.Add(new PersonalAccount(accNum, name, surname, pin));
        }
        public PersonalAccount GetAccount(string accNum)
        {
            foreach(PersonalAccount ac in personalAccounts)
            {
                if(ac.AccNum == accNum) { return ac; }
            }
            throw new AccountNotFoundException(accNum);
        }
        public void CloseAccount(string accNum)
        {
            if(GetAccount(accNum).Balance > 0)
            {
                throw new BalanceRemainingException(GetAccount(accNum).Balance);
            }
            else
            {
                personalAccounts.Remove(GetAccount(accNum));
            }
        }
        public override string ToString()
        {
            return name + " " + surname.ToUpper() + " has " + personalAccounts.Count() + " accounts";
        }
    }
}
