using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string msg) : base(msg)
        {
            
        }
    }
}
