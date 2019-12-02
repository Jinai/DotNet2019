using SMS.DataLayer.Entities;
using SMS.Shared;
using SMS.Shared.TransferObjects;
using System;
using System.Linq;

namespace SMS.DataLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static SandwichTO ToTO(this SandwichEF sandwichEF)
        {
            if (sandwichEF is null)
            {
                throw new ArgumentNullException(nameof(sandwichEF));
            }

            return new SandwichTO
            {
                Id = sandwichEF.Id,
                Name = new TranslatedString(sandwichEF.NameEnglish, sandwichEF.NameFrench, sandwichEF.NameDutch),
                Supplier = sandwichEF.Supplier.ToTO(),
                Ingredients = sandwichEF.SandwichIngredients?.Select(x => x.Ingredient.ToTO()).ToList()
            };
        }

        public static SandwichEF ToEF(this SandwichTO sandwichTO)
        {
            if (sandwichTO is null)
            {
                throw new ArgumentNullException(nameof(sandwichTO));
            }

            var sandwichEF = new SandwichEF
            {
                Id = sandwichTO.Id,
                NameEnglish = sandwichTO.Name.English,
                NameFrench = sandwichTO.Name.French,
                NameDutch = sandwichTO.Name.Dutch,
                Supplier = sandwichTO.Supplier.ToEF()
            };
            sandwichEF.SandwichIngredients = sandwichTO.Ingredients?.Select(x => new SandwichIngredientEF
            {
                Ingredient = x.ToEF(),
                IngredientId = x.Id,
                Sandwich = sandwichEF,
                SandwichId = sandwichTO.Id
            }).ToList();
            return sandwichEF;
        }
    }
}
