using System.Collections.Generic;

namespace SMS.Shared.BTO
{
    public class SandwichBTO
    {
        public int Id { get; set; }
        public TranslatedString Name { get; set; }
        public List<IngredientBTO> Ingredients { get; set; }
        public SupplierBTO Supplier { get; set; }
    }
}
