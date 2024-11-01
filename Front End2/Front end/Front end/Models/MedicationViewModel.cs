using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Front_end.Models
{
    public class MedicationViewModel
    {
        [DisplayName("MÃ")]
        public int MedicationId { get; set; }
        [Required]
        [DisplayName("TÊN THUỐC")]
        public string MedicationName { get; set; }
        [Required]
        [DisplayName("GIÁ TIỀN")]
        public decimal UnitPrice { get; set; }
        [Required]
        [DisplayName("TỒN KHO")]
        public int StockQuantity { get; set; }

        [Required]
        [DisplayName("MÔ TẢ")]
        public string MedicationDescription { get; set; }

    }
}
