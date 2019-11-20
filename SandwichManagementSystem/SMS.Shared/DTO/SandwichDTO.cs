using System.Collections.Generic;

namespace SMS.Shared.DTO
{
    public class SandwichDTO
    {
        public TranslatedString Name { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
