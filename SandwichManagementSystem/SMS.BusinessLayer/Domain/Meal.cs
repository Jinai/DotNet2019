using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.Domain
{
    public class Meal : DomainObject
    {
        public MealType MealType { get; set; }
        public TranslatedString Name { get; set; }
        public Supplier Supplier { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public bool HasAllergen()
        {
            return Ingredients.Any(i => i.IsAllergen);
        }

        public string ToString(Language lang)
        {
            var type = MealType.ToString();
            var name = Name.ToString(lang);
            var list = string.Join(", ", Ingredients.Select(x => x.ToString(lang)));
            return $"[{type}] {name} - {list}";
        }

        public override void CheckValidity()
        {
            base.CheckValidity();
            if (Name == null)
            {
                throw new InvalidMealException($"{nameof(Name)} cannot be null");
            }
            if (Supplier == null)
            {
                throw new InvalidMealException($"{nameof(Supplier)} cannot be null");
            }
            if (Ingredients == null)
            {
                throw new InvalidMealException($"{nameof(Ingredients)} cannot be null");
            }
        }
    }
}
