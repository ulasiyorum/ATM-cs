using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    internal class CustomerNotFoundException : SystemException
    {
        private int id;
        private string name;
        private string surname;
        public CustomerNotFoundException(int id)
        {
            this.id = id;
        }
        public CustomerNotFoundException(string name,string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public override string ToString()
        {
            return "Customer Cannot Be Found \n Name:" + name + "\nSurname:" + surname + "\nID:" + id;
        }
    }
}
