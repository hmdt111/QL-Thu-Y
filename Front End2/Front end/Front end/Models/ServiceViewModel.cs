using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class ServiceViewModel
    {
        [Key]
        [Column("ServiceID")]
        [DisplayName("MÃ")]
        public int ServiceId { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN DỊCH VỤ")]
        public string? ServiceName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("GIÁ")]
        public decimal? UnitPrice { get; set; }
    }
}
