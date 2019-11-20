using SMS.Shared.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataLayer.Entities
{
    [Table("Supplier")]
    public class SupplierEF
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Language LanguageChoice { get; set; }
        public bool IsCurrentSupplier { get; set; }
        public ICollection<SandwichEF> Sandwiches { get; set; }
    }
}
