using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    internal class CompanyNotFoundException : SystemException
    {
        private string name;
        private int id;
        public CompanyNotFoundException(string name)
        {
            this.name = name;
        }
        public CompanyNotFoundException(int id)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return "Company Cannot Be Found \nName:" + name + "\nId:" + id;
        }
    }
}
