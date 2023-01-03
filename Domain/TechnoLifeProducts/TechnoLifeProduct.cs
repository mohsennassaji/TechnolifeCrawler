using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechnoLifeProducts
{
    [Table("TechnoLifeProduct", Schema = "technolife")]
    public class TechnoLifeProduct
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }

        [Required, StringLength(1024)]
        public string Link { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [StringLength(1024)]
        public string ImageLink { get; set; }

        public float? MonitorSize { get; set; }

        public int? ProcessorCache { get; set; }

        public Unit? ProcessorCacheStorageUnit { get; set; }

        public int? Ram { get; set; }

        public Unit? RamStorageUnit { get; set; }

        public int? Hdd { get; set; }

        public Unit? HddStorageUnit { get; set; }

        public decimal? NormalPrice { get; set; }

        public float? DicsountPersentage { get; set; }

        public decimal? SellPrice { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<TechnoLifeProductImage>? ProductImages { get; set; }

        public TechnoLifeProductSpecification TechnoLifeProductSpecification { get; set; }
    }
}
