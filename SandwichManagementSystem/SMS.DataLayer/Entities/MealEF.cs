using SMS.Shared.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataLayer.Entities
{
    [Table("Meal")]
    public class MealEF
    {
        [Key]
        public int Id { get; set; }
        public MealType MealType { get; set; }
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public SupplierEF Supplier { get; set; }
        public ICollection<MealCompositionEF> MealCompositions { get; set; }
    }
}
