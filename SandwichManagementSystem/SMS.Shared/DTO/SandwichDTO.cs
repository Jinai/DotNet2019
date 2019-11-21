using System.Collections.Generic;

namespace SMS.Shared.DTO
{
    public class SandwichDTO
    {
        public int Id { get; set; }
        public TranslatedString Name { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
