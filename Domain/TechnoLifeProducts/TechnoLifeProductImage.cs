using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("TechnoLifeProductImage", Schema = "technolife")]
    public class TechnoLifeProductImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TechnoLifeProduct")]
        public int ProductId { get; set; }

        [Required, StringLength(1024)]
        public string ImageLink { get; set; }

        [Required]
        public TechnoLifeProduct Product { get; set; }
    }
}
