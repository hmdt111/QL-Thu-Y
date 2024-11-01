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
        public string? CustomerName { get; set; }

        [StringLength(10)]
        [DisplayName("SỐ ĐIỆN THOẠI")]

        public string? PhoneNumber { get; set; }
        [DisplayName("ĐỊA CHỈ")]
        public string? CustomerAddress { get; set; }

        [StringLength(100)]
        [DisplayName("EMAIL")]

        public string? CustomerEmail { get; set; }
    }
}
