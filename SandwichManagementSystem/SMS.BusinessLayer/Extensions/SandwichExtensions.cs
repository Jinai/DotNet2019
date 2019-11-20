using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.BTO;
using System;
using System.Linq;

namespace SMS.BusinessLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static SandwichBTO ToBTO(this Sandwich sandwich, Language lang)
        {
            return new SandwichBTO
            {
                Name = sandwich.Name.ToString(lang),
                Ingredients = String.Join(", ", sandwich.Ingredients.Select(x => x.ToString(lang)))
            };
        }
    }
}
