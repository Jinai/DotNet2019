using SMS.DataLayer.Entities;
using SMS.Shared;
using SMS.Shared.DTO;
using System;

namespace SMS.DataLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static IngredientDTO ToDTO(this IngredientEF ingredientEF)
        {
            if (ingredientEF is null)
            {
                throw new ArgumentNullException(nameof(ingredientEF));
            }

            return new IngredientDTO
            {
                Id = ingredientEF.Id,
                Name = new TranslatedString(ingredientEF.NameEnglish, ingredientEF.NameFrench, ingredientEF.NameDutch),
                IsAllergen = ingredientEF.IsAllergen,
            };
        }

        public static IngredientEF ToEF(this IngredientDTO ingredientDTO)
        {
            if (ingredientDTO is null)
            {
                throw new ArgumentNullException(nameof(ingredientDTO));
            }

            return new IngredientEF
            {
                Id = ingredientDTO.Id,
                NameEnglish = ingredientDTO.Name.English,
                NameFrench = ingredientDTO.Name.French,
                NameDutch = ingredientDTO.Name.Dutch,
                IsAllergen = ingredientDTO.IsAllergen
            };
        }
    }
}
