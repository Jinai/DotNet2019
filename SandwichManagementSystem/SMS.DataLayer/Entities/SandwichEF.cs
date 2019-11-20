using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataLayer.Entities
{
    [Table("Sandwich")]
    public class SandwichEF
    {
        [Key]
        public int Id { get; set; }
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public SupplierEF Supplier { get; set; }
        public ICollection<SandwichIngredientEF> SandwichIngredients { get; set; }
    }
}
