using System;

namespace SMS.Shared.Exceptions
{
    public class InvalidSupplierException : DomainException
    {
        public InvalidSupplierException() { }

        public InvalidSupplierException(string message)
            : base(message) { }

        public InvalidSupplierException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
