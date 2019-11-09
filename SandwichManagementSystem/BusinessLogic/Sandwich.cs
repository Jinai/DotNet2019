using System.Collections.Generic;
using System.Linq;

namespace SMSBusinessLogic
{
    public class Sandwich
    {
        public TranslatedString Name { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public List<Ingredient> Ingredients { get; }

        public Sandwich()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public Sandwich(TranslatedString name, Fournisseur fournisseur) : this()
        {
            this.Name = name;
            this.Fournisseur = fournisseur;
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
