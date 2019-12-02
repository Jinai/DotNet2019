using SMS.Shared.Enums;
using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Domain
{
    public class Supplier : DomainObject
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Language LanguageChoice { get; set; }
        public bool IsDefault { get; set; }

        public override void CheckValidity()
        {
            base.CheckValidity();
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidSupplierException($"{nameof(Name)} cannot be null or empty");
            }
            if (string.IsNullOrEmpty(ContactName) || string.IsNullOrWhiteSpace(ContactName))
            {
                throw new InvalidSupplierException($"{nameof(ContactName)} cannot be null or empty");
            }
            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
            {
                throw new InvalidSupplierException($"{nameof(Email)} cannot be null or empty");
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Email}) - {ContactName}";
        }
    }
}
