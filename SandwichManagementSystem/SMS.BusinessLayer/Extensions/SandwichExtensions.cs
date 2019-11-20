using SMS.BusinessLayer.Domain;
using SMS.Shared.BTO;
using SMS.Shared.DTO;
using System;
using System.Linq;

namespace SMS.BusinessLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static SandwichBTO ToBTO(this Sandwich sandwich)
        {
            if (sandwich is null)
            {
                throw new ArgumentNullException(nameof(sandwich));
            }

            return new SandwichBTO
            {
                Id = sandwich.Id,
                Name = sandwich.Name,
                Supplier = sandwich.Supplier.ToBTO(),
                Ingredients = sandwich.Ingredients?.Select(x => x.ToBTO()).ToList()
            };
        }

        public static Sandwich ToDomain(this SandwichBTO sandwichBTO)
        {
            if (sandwichBTO is null)
            {
                throw new ArgumentNullException(nameof(sandwichBTO));
            }

            return new Sandwich
            {
                Id = sandwichBTO.Id,
                Name = sandwichBTO.Name,
                Supplier = sandwichBTO.Supplier.ToDomain(),
                Ingredients = sandwichBTO.Ingredients?.Select(x => x.ToDomain()).ToList()
            };
        }

        public static SandwichDTO ToDTO(this Sandwich sandwich)
        {
            if (sandwich is null)
            {
                throw new ArgumentNullException(nameof(sandwich));
            }

            return new SandwichDTO
            {
                Id = sandwich.Id,
                Name = sandwich.Name,
                Supplier = sandwich.Supplier.ToDTO(),
                Ingredients = sandwich.Ingredients?.Select(x => x.ToDTO()).ToList()
            };
        }

        public static Sandwich ToDomain(this SandwichDTO sandwichDTO)
        {
            if (sandwichDTO is null)
            {
                throw new ArgumentNullException(nameof(sandwichDTO));
            }

            return new Sandwich
            {
                Id = sandwichDTO.Id,
                Name = sandwichDTO.Name,
                Supplier = sandwichDTO.Supplier.ToDomain(),
                Ingredients = sandwichDTO.Ingredients?.Select(x => x.ToDomain()).ToList()
            };
        }
    }
}
