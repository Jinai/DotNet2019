using System;

namespace SMS.Shared.Exceptions
{
    public class InvalidSandwichException : DomainException
    {
        public InvalidSandwichException() { }

        public InvalidSandwichException(string message)
            : base(message) { }

        public InvalidSandwichException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
