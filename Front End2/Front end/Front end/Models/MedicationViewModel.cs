using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Front_end.Models
{
    public class MedicationViewModel
    {
        [DisplayName("MÃ")]
        public int MedicationId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên thuốc.")]
        [DisplayName("TÊN THUỐC")]
        public string MedicationName { get; set; }

        
        [DisplayName("GIÁ TIỀN")]
        [Required(ErrorMessage = "Vui lòng nhập giá tiền.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0.")]
        [DataType(DataType.Currency, ErrorMessage = "Định dạng giá tiền không hợp lệ.")]
       
        public decimal UnitPrice { get; set; }

        
        [DisplayName("TỒN KHO")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng tồn.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0.")]
       
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        [DisplayName("MÔ TẢ")]
        public string MedicationDescription { get; set; }

    }
}
