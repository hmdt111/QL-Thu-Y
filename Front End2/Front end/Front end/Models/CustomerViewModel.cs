using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class CustomerViewModel
    {
        [Key]
        [Column("CustomerID")]
        [DisplayName("MÃ")]

        public int CustomerId { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN KHÁCH HÀNG")]
        [Required(ErrorMessage = "Chưa nhập họ và tên")]
        public string? CustomerName { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [MaxLength(10, ErrorMessage = "Tối đa 10 kí tự ")]
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Chưa đúng định dạng")]
        [DisplayName("SỐ ĐIỆN THOẠI")]

        public string? PhoneNumber { get; set; }
        [DisplayName("ĐỊA CHỈ")]
        [Required(ErrorMessage = "Chưa nhập địa chỉ")]
        public string? CustomerAddress { get; set; }

        [StringLength(100)]
        [DisplayName("EMAIL")]
        [EmailAddress(ErrorMessage = "Chưa đúng định dạng email")]
        [Required(ErrorMessage = "Chưa nhập email")]
        public string? CustomerEmail { get; set; }
    }
}
