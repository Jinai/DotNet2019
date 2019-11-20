namespace SMS.Shared.DTO
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public TranslatedString Name { get; set; }
        public bool IsAllergen { get; set; }
    }
}
