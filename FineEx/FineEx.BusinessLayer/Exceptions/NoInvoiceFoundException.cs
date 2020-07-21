using System;
using System.Runtime.Serialization;

namespace FineEx.BusinessLayer.Exceptions
{
    public class NoInvoiceFoundException : Exception
    {
        public NoInvoiceFoundException()
        {
        }

        public NoInvoiceFoundException(string message) : base(message)
        {
        }

        public NoInvoiceFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoInvoiceFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}