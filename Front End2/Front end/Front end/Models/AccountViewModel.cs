using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class AccountViewModel
    {
        [Key]
        [Column("AccountID")]
        [DisplayName("MÃ")]
        public int AccountId { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN NGƯỜI DÙNG")]
        public string? Username { get; set; }

        [StringLength(100)]
        [DisplayName("MẬT KHẨU")]
        public string? Pass { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN NHÂN VIÊN")]
        public string? EmployeeName { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("NGÀY TẠO")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("ĐĂNG NHẬP CUỐI")]
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
    }
}
