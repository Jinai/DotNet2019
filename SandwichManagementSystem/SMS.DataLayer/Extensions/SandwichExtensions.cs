using SMS.DataLayer.Entities;
using SMS.Shared;
using SMS.Shared.DTO;
using System;
using System.Linq;

namespace SMS.DataLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static SandwichDTO ToDTO(this SandwichEF sandwichEF)
        {
            if (sandwichEF is null)
            {
                throw new ArgumentNullException(nameof(sandwichEF));
            }

            return new SandwichDTO
            {
                Id = sandwichEF.Id,
                Name = new TranslatedString(sandwichEF.NameEnglish, sandwichEF.NameFrench, sandwichEF.NameDutch),
                Supplier = sandwichEF.Supplier.ToDTO(),
                Ingredients = sandwichEF.SandwichIngredients?.Select(x => x.Ingredient.ToDTO()).ToList()
            };
        }

        public static SandwichEF ToEF(this SandwichDTO sandwichDTO)
        {
            if (sandwichDTO is null)
            {
                throw new ArgumentNullException(nameof(sandwichDTO));
            }

            var sandwichEF = new SandwichEF
            {
                Id = sandwichDTO.Id,
                NameEnglish = sandwichDTO.Name.English,
                NameFrench = sandwichDTO.Name.French,
                NameDutch = sandwichDTO.Name.Dutch,
                Supplier = sandwichDTO.Supplier.ToEF()
            };
            sandwichEF.SandwichIngredients = sandwichDTO.Ingredients?.Select(x => new SandwichIngredientEF
            {
                Ingredient = x.ToEF(),
                IngredientId = x.Id,
                Sandwich = sandwichEF,
                SandwichId = sandwichDTO.Id
            }).ToList();
            return sandwichEF;
        }
    }
}
