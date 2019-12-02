using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.Domain
{
    public class Sandwich : DomainObject
    {
        public TranslatedString Name { get; set; }
        public Supplier Supplier { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public bool HasAllergen()
        {
            return Ingredients.Any(i => i.IsAllergen);
        }

        public string ToString(Language lang)
        {
            string name = Name.ToString(lang);
            string list = string.Join(", ", Ingredients.Select(x => x.ToString(lang)));
            return $"{name} - {list}";
        }

        public override void CheckValidity()
        {
            base.CheckValidity();
            if (Name == null)
            {
                throw new InvalidSandwichException($"{nameof(Name)} cannot be null");
            }
            if (Supplier == null)
            {
                throw new InvalidSandwichException($"{nameof(Supplier)} cannot be null");
            }
            if (Ingredients == null)
            {
                throw new InvalidSandwichException($"{nameof(Ingredients)} cannot be null");
            }
        }
    }
}
