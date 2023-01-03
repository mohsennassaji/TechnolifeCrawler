using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SystemEntities
{
    [Table("LogManagment", Schema = "base")]
    public class LogManagment
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(2048)]
        public string Message { get; set; }

        [StringLength(100)]
        public string? ClassName { get; set; }

        [StringLength(200)]
        public string? MethodName { get; set; }

        [StringLength(200)]
        public string? GroupName { get; set; }

        [StringLength(4096)]
        public string? StackTrace { get; set; }
    }
}
