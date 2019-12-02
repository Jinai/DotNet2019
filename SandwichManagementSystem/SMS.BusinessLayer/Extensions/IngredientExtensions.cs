using SMS.BusinessLayer.Domain;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.BusinessLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static Ingredient ToDomain(this IngredientTO ingredientTO)
        {
            if (ingredientTO is null)
            {
                throw new ArgumentNullException(nameof(ingredientTO));
            }

            return new Ingredient
            {
                Id = ingredientTO.Id,
                Name = ingredientTO.Name,
                IsAllergen = ingredientTO.IsAllergen
            };
        }

        public static IngredientTO ToTO(this Ingredient ingredient)
        {
            if (ingredient is null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            return new IngredientTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen
            };
        }
    }
}
