using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("TechnoLifeProductSpecification", Schema = "technolife")]
    public class TechnoLifeProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TechnoLifeProduct")]
        public int ProductId { get; set; }

        [StringLength(100)]
        public string? Dimantions { get; set; }

        [StringLength(50)]
        public string? Weight { get; set; }

        [Required]
        public TechnoLifeProduct Product { get; set; }
    }
}
