namespace SMS.Shared.BTO
{
    public class IngredientBTO
    {
        public int Id { get; set; }
        public TranslatedString Name { get; set; }
        public bool IsAllergen { get; set; }
    }
}