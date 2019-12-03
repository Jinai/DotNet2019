using SMS.Shared.Enums;
using System.Collections.Generic;

namespace SMS.Shared.TransferObjects
{
    public class MealTO
    {
        public int Id { get; set; }
        public MealType MealType { get; set; }
        public TranslatedString Name { get; set; }
        public SupplierTO Supplier { get; set; }
        public List<IngredientTO> Ingredients { get; set; }
    }
}
