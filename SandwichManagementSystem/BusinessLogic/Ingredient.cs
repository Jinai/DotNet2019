namespace SMSBusinessLogic
{
    public class Ingredient
    {
        public TranslatedString Name;
        public bool IsAllergen { get; set; }

        public Ingredient() { }

        public Ingredient(TranslatedString name, bool allergen = false)
        {
            this.Name = name;
            this.IsAllergen = allergen;
        }

        public string ToString(Language lang)
        {
            string name = this.Name.ToString(lang);
            return (this.IsAllergen) ? name + "*" : name;
        }
    }
}
