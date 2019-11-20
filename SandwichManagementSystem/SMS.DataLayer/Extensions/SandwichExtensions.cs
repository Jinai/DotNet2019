using SMS.DataLayer.Entities;
using SMS.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataLayer.Extensions
{
    public static class SandwichExtensions
    {
        public static SandwichDTO ToDTO(this SandwichEF sandwich)
        {
            return new SandwichDTO
            {
            };
        }
        public static SandwichEF ToEF(this SandwichDTO sandwich)
        {
            return new SandwichEF()
            {
                NameEnglish = sandwich.Name.English,
                NameFrench = sandwich.Name.French,
                NameDutch = sandwich.Name.Dutch,

                Ingredients = sandwich.Ingredients.Select(x => x.ToEF()).ToList()
            };
        }
    }
}
