using SMS.Shared;
using System;

namespace SMS.BusinessLayer.Domain
{
    public class Ingredient
    {
        public TranslatedString Name { get; set; }
        public bool IsAllergen { get; set; }

        public Ingredient() { }

        public Ingredient(TranslatedString name, bool isAllergen = false)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(Name));
            this.IsAllergen = isAllergen;
        }

        public string ToString(Language lang)
        {
            string name = this.Name.ToString(lang);
            return (this.IsAllergen) ? name + "*" : name;
        }
    }
}
