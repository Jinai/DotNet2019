using SMS.Shared.Enums;

namespace SMS.Shared.TransferObjects
{
    public class SupplierTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Language LanguageChoice { get; set; }
        public bool IsDefault { get; set; }
    }
}
