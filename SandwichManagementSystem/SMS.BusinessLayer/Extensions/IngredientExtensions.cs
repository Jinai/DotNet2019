using SMS.BusinessLayer.Domain;
using SMS.Shared.BTO;
using SMS.Shared.DTO;
using System;

namespace SMS.BusinessLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static IngredientBTO ToBTO(this Ingredient ingredient)
        {
            if (ingredient is null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            return new IngredientBTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen
            };
        }

        public static Ingredient ToDomain(this IngredientBTO ingredientBTO)
        {
            if (ingredientBTO is null)
            {
                throw new ArgumentNullException(nameof(ingredientBTO));
            }

            return new Ingredient
            {
                Id = ingredientBTO.Id,
                Name = ingredientBTO.Name,
                IsAllergen = ingredientBTO.IsAllergen
            };
        }

        public static IngredientDTO ToDTO(this Ingredient ingredient)
        {
            if (ingredient is null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            return new IngredientDTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen
            };
        }

        public static Ingredient ToDomain(this IngredientDTO ingredientDTO)
        {
            if (ingredientDTO is null)
            {
                throw new ArgumentNullException(nameof(ingredientDTO));
            }

            return new Ingredient
            {
                Id = ingredientDTO.Id,
                Name = ingredientDTO.Name,
                IsAllergen = ingredientDTO.IsAllergen
            };
        }
    }
}
