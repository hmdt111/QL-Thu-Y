using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class AppointmentViewModel
    {
        [Key]
        [Column("AppointmentID")]
        [DisplayName("MÃ")]
        public int AppointmentId { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("NGÀY HẸN")]
        public DateTime? AppointmentDate { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN KHÁCH HÀNG")]
        public string? CustomerName { get; set; }
        [StringLength(100)]
        [DisplayName("TÊN THÚ CƯNG")]
        public string? PetName { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN NHÂN VIÊN")]
        public string? EmployeeName { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN DỊCH VỤ")]
        public string? ServiceName { get; set; }

        [DisplayName("GHI CHÚ")]
        public string? Note { get; set; }
    }
}
