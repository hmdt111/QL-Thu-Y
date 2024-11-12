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
        [Required(ErrorMessage = "Chưa nhập tên dịch vụ")]
        public string? ServiceName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("GIÁ")]
        [Required(ErrorMessage = "Vui lòng nhập giá tiền.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0.")]
        [DataType(DataType.Currency, ErrorMessage = "Định dạng giá tiền không hợp lệ.")]
        public decimal? UnitPrice { get; set; }
    }
}
