using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSBusinessLogic
{
    public class Sandwich
    {
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public List<Ingredient> Ingredients { get; }

        public Sandwich()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public Sandwich(string nameEnglish, string nameFrench, string nameDutch, Fournisseur fournisseur) : this()
        {
            this.NameEnglish = nameEnglish;
            this.NameFrench = nameFrench;
            this.NameDutch = nameDutch;
            this.Fournisseur = fournisseur;
        }

        public bool HasAllergen()
        {
            foreach (Ingredient ing in this.Ingredients)
            {
                if (ing.Allergen)
                    return true;
            }
            return false;
        }

        public string ToString(Language lang)
        {
            StringBuilder Result = new StringBuilder();
            switch (lang)
            {
                case Language.English:
                    Result.Append(this.NameEnglish);
                    break;
                case Language.French:
                    Result.Append(this.NameFrench);
                    break;
                case Language.Dutch:
                    Result.Append(this.NameDutch);
                    break;
            }
            Result.Append(" - ");
            Result.Append(string.Join(", ", Ingredients.Select(x => x.ToString(lang))));
            return Result.ToString();
        }
    }
}
