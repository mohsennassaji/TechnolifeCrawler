using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("ProductImage", Schema = "app")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required, StringLength(1024)]
        public string ImageLink { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
