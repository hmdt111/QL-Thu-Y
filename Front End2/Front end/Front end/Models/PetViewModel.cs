using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class PetViewModel
    {

        [Key]
        [Column("PetID")]
        [DisplayName("MÃ")]
        public int PetId { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN THÚ CƯNG")]
        public string? PetName { get; set; }

        [StringLength(100)]
        [DisplayName("LOÀI")]
        public string? Species { get; set; }

        [StringLength(50)]
        [DisplayName("GIỐNG")]
        public string? Breed { get; set; }

        [DisplayName("LỊCH SỬ DÙNG THUỐC")]
        public string? MedicalHistory { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN KHÁCH HÀNG")]
        public string? CustomerName { get; set; }
    }
}
