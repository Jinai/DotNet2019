using System;

namespace SMS.Shared.Exceptions
{
    public class InvalidIngredientException : DomainException
    {
        public InvalidIngredientException() { }

        public InvalidIngredientException(string message)
            : base(message) { }

        public InvalidIngredientException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
