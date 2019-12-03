using SMS.DataLayer.Entities;
using SMS.Shared;
using SMS.Shared.TransferObjects;
using System;
using System.Linq;

namespace SMS.DataLayer.Extensions
{
    public static class MealExtensions
    {
        public static MealTO ToTO(this MealEF mealEF)
        {
            if (mealEF is null)
            {
                throw new ArgumentNullException(nameof(mealEF));
            }

            return new MealTO
            {
                Id = mealEF.Id,
                MealType = mealEF.MealType,
                Name = new TranslatedString(mealEF.NameEnglish, mealEF.NameFrench, mealEF.NameDutch),
                Supplier = mealEF.Supplier.ToTO(),
                Ingredients = mealEF.MealCompositions?.Select(x => x.Ingredient.ToTO()).ToList()
            };
        }

        public static MealEF ToEF(this MealTO mealTO)
        {
            if (mealTO is null)
            {
                throw new ArgumentNullException(nameof(mealTO));
            }

            var mealEF = new MealEF
            {
                Id = mealTO.Id,
                MealType = mealTO.MealType,
                NameEnglish = mealTO.Name.English,
                NameFrench = mealTO.Name.French,
                NameDutch = mealTO.Name.Dutch,
                Supplier = mealTO.Supplier.ToEF()
            };
            mealEF.MealCompositions = mealTO.Ingredients?.Select(x => new MealCompositionEF
            {
                Ingredient = x.ToEF(),
                IngredientId = x.Id,
                Meal = mealEF,
                MealId = mealTO.Id
            }).ToList();
            return mealEF;
        }
    }
}
