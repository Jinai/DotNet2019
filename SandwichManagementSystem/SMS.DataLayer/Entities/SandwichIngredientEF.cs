using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.DataLayer.Entities
{
    [Table("SandwichIngredient")]
    public class SandwichIngredientEF
    {
        public int SandwichId { get; set; }
        public SandwichEF Sandwich { get; set; }
        public int IngredientId { get; set; }
        public IngredientEF Ingredient { get; set; }
    }
}
