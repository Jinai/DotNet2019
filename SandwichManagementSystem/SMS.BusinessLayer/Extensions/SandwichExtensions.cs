using SMS.BusinessLayer.Domain;
using SMS.Shared.TransferObjects;
using System;
using System.Linq;

namespace SMS.BusinessLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static Sandwich ToDomain(this SandwichTO sandwichTO)
        {
            if (sandwichTO is null)
            {
                throw new ArgumentNullException(nameof(sandwichTO));
            }

            var sandwich = new Sandwich
            {
                Id = sandwichTO.Id,
                Name = sandwichTO.Name,
                Supplier = sandwichTO.Supplier.ToDomain(),
                Ingredients = sandwichTO.Ingredients?.Select(x => x.ToDomain()).ToList()
            };

            sandwich.CheckValidity();

            return sandwich;
        }

        public static SandwichTO ToTO(this Sandwich sandwich)
        {
            if (sandwich is null)
            {
                throw new ArgumentNullException(nameof(sandwich));
            }

            return new SandwichTO
            {
                Id = sandwich.Id,
                Name = sandwich.Name,
                Supplier = sandwich.Supplier.ToTO(),
                Ingredients = sandwich.Ingredients?.Select(x => x.ToTO()).ToList()
            };
        }
    }
}
