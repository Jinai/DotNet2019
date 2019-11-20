using SMS.DataLayer.Entities;
using SMS.Shared.DTO;

namespace SMS.DataLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static IngredientDTO ToDTO(this IngredientEF ingredient)
        {
            return new IngredientDTO
            {

            };
        }
        public static IngredientEF ToEF(this IngredientDTO ingredient)
        {
            return new IngredientEF()
            {
                NameEnglish = ingredient.Name.English,
                NameFrench = ingredient.Name.French,
                NameDutch = ingredient.Name.Dutch,
                IsAllergen = ingredient.IsAllergen
            };
        }
    }
}
