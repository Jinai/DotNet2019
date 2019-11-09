using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLogic
{
    public class Sandwich
    {
        public TranslatedString Name { get; set; }
        public Supplier Supplier { get; set; }
        public List<Ingredient> Ingredients { get; }

        public Sandwich()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public Sandwich(TranslatedString name, Supplier supplier) : this()
        {
            this.Name = name;
            this.Supplier = supplier;
        }

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
    }
}
