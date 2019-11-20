using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataLayer.Entities
{
    [Table("Ingredient")]
    public class IngredientEF
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool IsAllergen { get; set; }
    }
}
