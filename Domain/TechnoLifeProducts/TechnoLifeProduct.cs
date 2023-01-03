using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("TechnoLifeProduct", Schema = "app")]
    public class TechnoLifeProduct
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(1024)]
        public string Link { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }


    }
}
