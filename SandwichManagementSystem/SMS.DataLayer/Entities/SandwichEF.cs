using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.DataLayer.Entities
{
    [Table("Sandwich")]
    public class SandwichEF
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public ICollection<IngredientEF> Ingredients { get; set; }
    }
}
