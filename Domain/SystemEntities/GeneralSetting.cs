using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SystemEntities
{
    [Table("GeneralSetting", Schema = "base")]
    public class GeneralSetting
    {
        public long Id { get; set; }

        [Required, StringLength(100)]
        public string Key { get; set; }

        [Required, StringLength(1024)]
        public string Value { get; set; }
    }
}
