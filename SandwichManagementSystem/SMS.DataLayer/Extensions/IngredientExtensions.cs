using SMS.DataLayer.Entities;
using SMS.Shared;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.DataLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static IngredientTO ToTO(this IngredientEF ingredientEF)
        {
            if (ingredientEF is null)
            {
                throw new ArgumentNullException(nameof(ingredientEF));
            }

            return new IngredientTO
            {
                Id = ingredientEF.Id,
                Name = new TranslatedString(ingredientEF.NameEnglish, ingredientEF.NameFrench, ingredientEF.NameDutch),
                IsAllergen = ingredientEF.IsAllergen,
            };
        }

        public static IngredientEF ToEF(this IngredientTO ingredientTO)
        {
            if (ingredientTO is null)
            {
                throw new ArgumentNullException(nameof(ingredientTO));
            }

            return new IngredientEF
            {
                Id = ingredientTO.Id,
                NameEnglish = ingredientTO.Name.English,
                NameFrench = ingredientTO.Name.French,
                NameDutch = ingredientTO.Name.Dutch,
                IsAllergen = ingredientTO.IsAllergen
            };
        }
    }
}
