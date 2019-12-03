using SMS.BusinessLayer.Domain;
using SMS.Shared.TransferObjects;
using System;
using System.Linq;

namespace SMS.BusinessLayer.Extensions
{
    public static class MealExtensions
    {
        public static Meal ToDomain(this MealTO mealTO)
        {
            if (mealTO is null)
            {
                throw new ArgumentNullException(nameof(mealTO));
            }

            var meal = new Meal
            {
                Id = mealTO.Id,
                MealType = mealTO.MealType,
                Name = mealTO.Name,
                Supplier = mealTO.Supplier.ToDomain(),
                Ingredients = mealTO.Ingredients?.Select(x => x.ToDomain()).ToList()
            };

            meal.CheckValidity();

            return meal;
        }

        public static MealTO ToTO(this Meal meal)
        {
            if (meal is null)
            {
                throw new ArgumentNullException(nameof(meal));
            }

            return new MealTO
            {
                Id = meal.Id,
                MealType = meal.MealType,
                Name = meal.Name,
                Supplier = meal.Supplier.ToTO(),
                Ingredients = meal.Ingredients?.Select(x => x.ToTO()).ToList()
            };
        }
    }
}
