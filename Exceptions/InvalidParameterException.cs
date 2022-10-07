using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Exceptions
{
    internal class InvalidParameterException : SystemException
    {
        string parameterName;

        public InvalidParameterException(string parameterName)
        {
            this.parameterName = parameterName;
        }

        public override string ToString()
        {
            return parameterName;
        }
    }
}
