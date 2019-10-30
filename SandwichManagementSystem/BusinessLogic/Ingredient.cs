using System;
using System.Collections.Generic;
using System.Text;

namespace SMSBusinessLogic
{
    public class Ingredient
    {
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool Allergen { get; set; }

        public Ingredient() { }

        public Ingredient(string nameEnglish, string nameFrench, string nameDutch, bool allergen = false)
        {
            this.NameEnglish = nameEnglish;
            this.NameFrench = nameFrench;
            this.NameDutch = nameDutch;
            this.Allergen = allergen;
        }

        public string ToString(Language lang)
        {
            StringBuilder result = new StringBuilder();
            switch (lang)
            {
                case Language.English:
                    result.Append(this.NameEnglish);
                    break;
                case Language.French:
                    result.Append(this.NameFrench);
                    break;
                case Language.Dutch:
                    result.Append(this.NameDutch);
                    break;
            }
            if (this.Allergen)
                result.Append("*");
            return result.ToString();
        }
    }
}
