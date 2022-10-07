using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATM.Exceptions;

namespace ATM.Project
{
    internal class Company
    {
        private string companyName;
        private int id;
        private List<BusinessAccount> businessAccounts = new();
        private static List<Company> companies = new();


        public string CompanyName { get => companyName; }
        public int Id { get => id; }
        public List<BusinessAccount> BusinessAccounts { get => businessAccounts; }

        internal Company(string companyName, int id)
        {
            this.companyName = companyName;
            Random random = new Random();
            do
            {
                this.id = id > 0 && id.ToString().Length == 4 ? id : random.Next(1000, 9999); ;
                foreach (Company c in companies)
                {
                    if (c.id == this.id) { this.id = 0; }
                }
            } while (id == 0);
            companies.Add(this);
        }

        public void OpenAccount(string accNum)
        {
            businessAccounts.Add(new BusinessAccount(accNum,0));
        }
        public void OpenAccount(string accNum,double interestRate)
        {
            businessAccounts.Add(new BusinessAccount(accNum, interestRate));
        }

        public BusinessAccount GetAccount(string accNum)
        {
            foreach(var b in businessAccounts)
            {
                if(b.AccNum == accNum) { return b; }
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
                businessAccounts.Remove(GetAccount(accNum));
            }
        }

        public override string ToString()
        {
            return companyName.ToUpper() + " Company has " + businessAccounts.Count() + " accounts.";   
        }
    }
}
