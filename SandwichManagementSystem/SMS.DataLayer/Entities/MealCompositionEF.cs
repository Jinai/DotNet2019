using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataLayer.Entities
{
    [Table("MealComposition")]
    public class MealCompositionEF
    {
        public int MealId { get; set; }
        public MealEF Meal { get; set; }
        public int IngredientId { get; set; }
        public IngredientEF Ingredient { get; set; }
    }
}
