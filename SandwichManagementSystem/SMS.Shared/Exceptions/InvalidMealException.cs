using System;

namespace SMS.Shared.Exceptions
{
    public class InvalidMealException : DomainException
    {
        public InvalidMealException() { }

        public InvalidMealException(string message)
            : base(message) { }

        public InvalidMealException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
