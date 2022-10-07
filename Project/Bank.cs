using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Exceptions;

namespace ATM.Project
{
    internal class Bank
    {
        private string bankName;
        private string bankAddress;
        private List<Account> accounts = new();
        private List<Company> companies = new();
        private List<Customer> customers = new();

        public string BankName { get => bankName; }
        public string BankAddress { get => bankAddress; }
        public List<Account> Accounts { get => accounts; }
        public List<Company> Companies { get => companies; }
        public List<Customer> Customers { get => customers; }
        public Bank(string name,string address)
        {
            bankAddress = address;
            bankName = name.ToUpper();
        }

        public void ProcessTransactions(Collection<Transaction> transactions,string logFile) 
        {
            var file = File.CreateText(logFile);
            Transaction[] transactionsArray = Sort(transactions);
            foreach(Transaction t in transactionsArray)
            {
                try
                {
                    if (t.Type == 1)
                    {
                        GetAccount(t.To).Deposit(t.Amount);
                        file.WriteLine(t.ToString());
                    }
                    else if (t.Type == 2)
                    {
                        TransferFunds(t.From, t.To, t.Amount);
                        file.WriteLine(t.ToString());
                    }
                    else if (t.Type == 3)
                    {
                        GetAccount(t.From).Withdraw(t.Amount);
                        file.WriteLine(t.ToString());
                    }
                } catch(Exception e)
                {
                    file.WriteLine("ERROR: " + e.ToString() + " with type:" + t.Type 
                        + " from:" + t.From + " to:" + t.To + " amount:" + t.Amount);
                }
                finally
                {
                    file.Flush();
                }
            }
            file.Close();
        }
        
        public void TransferFunds(string from, string to, double amount)
        {
            if(GetAccount(from).Balance < amount || amount <0) { throw new InvalidAmountException(amount); }
            else
            {
                GetAccount(from).Withdraw(amount);
                GetAccount(to).Deposit(amount);
            }
        }

        public Account GetAccount(string accNum)
        {
            foreach(Account a in accounts)
            {
                if(a.AccNum == accNum)
                {
                return a;
                }
            }
            throw new AccountNotFoundException(accNum);
        }
        public void CloseAccount(string accNum)
        {
           if(GetAccount(accNum).Balance > 0) { throw new BalanceRemainingException(GetAccount(accNum).Balance); }
           else
           {
                accounts.Remove(GetAccount(accNum));
           }
        }

        public Transaction[] Sort(Collection<Transaction> transactions)
        {
            List<Transaction> result = new(transactions);
            result.Sort(new Transaction.TransactionComparator());
            return result.ToArray();
        }

        public void AddCustomer(int id, string name, string surname)
        {
            customers.Add(new Customer(id, name, surname));
        }
        public void AddCompany(int id, string name)
        {
            companies.Add(new Company(name, id));
        }
        public void AddAccount(Account account) { accounts.Add(account); }

        public Customer GetCustomer(string name,string surname)
        {
            foreach(Customer c in customers)
            {
                if(c.Name + c.Surname == name + surname) { return c; }
            }
            throw new CustomerNotFoundException(name,surname);
        }
        public Customer GetCustomer(int id)
        {
            foreach(Customer c in customers)
            {
                if(c.Id == id)
                {
                    return c;
                }
            }

            throw new CustomerNotFoundException(id);
        }

        public Company GetCompany(string name)
        {
            foreach (Company c in companies)
            {
                if (c.CompanyName == name) { return c; }
            }
            throw new CompanyNotFoundException(name);
        }
        public Company GetCompany(int id)
        {
            foreach(Company c in companies)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            throw new CompanyNotFoundException(id);
        }
        public override string ToString()
        {
            string toReturn = BankName.ToUpper() + " " + BankAddress.ToUpper() + "\n";
            for (int i = 0; i < companies.Count(); i++)
            {
                toReturn += companies[i].CompanyName + "\n";
                for(int j=0; j < companies[i].BusinessAccounts.Count(); j++)
                {
                    toReturn += companies[i].BusinessAccounts[j].AccNum + "    " +
                        companies[i].BusinessAccounts[j].InterestRate + "    " +
                        companies[i].BusinessAccounts[j].Balance + "\n";
                }
            }
            for(int i=0; i<customers.Count(); i++)
            {
                toReturn += customers[i].Name + " " + customers[i].Surname.ToUpper() + "\n";
                for(int j=0; j < customers[i].PersonalAccounts.Count(); j++)
                {
                    toReturn += customers[i].PersonalAccounts[j].AccNum + "    " +
                        customers[i].PersonalAccounts[j].Balance + "\n";
                }
            }
            return toReturn;
        }
    }
}
