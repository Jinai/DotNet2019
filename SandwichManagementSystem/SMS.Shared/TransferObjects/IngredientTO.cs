namespace SMS.Shared.TransferObjects
{
    public class IngredientTO
    {
        public int Id { get; set; }
        public TranslatedString Name { get; set; }
        public bool IsAllergen { get; set; }
    }
}
