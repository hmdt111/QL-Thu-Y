using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_end.Models
{
    public class RoleViewModel
    {
        [Key]
        [Column("RoleID")]
        [DisplayName("MÃ")]
        public int RoleId { get; set; }

        [StringLength(100)]
        [DisplayName("TÊN CHỨC VỤ")]
        [Required(ErrorMessage = "Vui lòng nhập tên chức vụ")]
        public string? RoleName { get; set; }
        [DisplayName("MÔ TẢ")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả chức vụ")]
        public string? RoleDescription { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
