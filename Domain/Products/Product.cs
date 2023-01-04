using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("Product", Schema = "app")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }

        [Required, StringLength(1024)]
        public string Link { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public ProductProvider ProductProvider { get; set; }

        [StringLength(1024)]
        public string ImageLink { get; set; }

        public float? MonitorSize { get; set; }

        public string? ProcessorCache { get; set; }

        public string? Ram { get; set; }

        public string? Hdd { get; set; }

        public decimal? NormalPrice { get; set; }

        public float? DicsountPersentage { get; set; }

        public decimal? SellPrice { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }

        public ProductSpecification ProductSpecification { get; set; }
    }
}
