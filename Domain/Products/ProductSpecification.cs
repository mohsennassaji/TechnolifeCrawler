using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("ProductSpecification", Schema = "app")]
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [StringLength(100)]
        public string? Dimantions { get; set; }

        [StringLength(50)]
        public string? Weight { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
