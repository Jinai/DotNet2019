using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Domain
{
    public class Ingredient : DomainObject
    {
        public TranslatedString Name { get; set; }
        public bool IsAllergen { get; set; }

        public string ToString(Language lang)
        {
            var name = Name.ToString(lang);
            return (IsAllergen) ? name + "*" : name;
        }

        public override void CheckValidity()
        {
            base.CheckValidity();
            if (Name == null)
            {
                throw new InvalidIngredientException($"{nameof(Name)} cannot be null");
            }
        }
    }
}
