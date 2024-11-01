using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Principal;

namespace Front_end.Models
{
    public class EmployeeViewModel
    {
        [DisplayName("MÃ")]
        public int EmployeeId { get; set; }
        [DisplayName("TÊN NHÂN VIÊN")]
        public string EmployeeName { get; set; }
        [DisplayName("SỐ ĐIỆN THOẠI")]
        public string PhoneNumber { get; set; }
        [DisplayName("EMAIL")]
        public string EmployeeEmail { get; set; }
        [DisplayName("NGÀY TẠO")]
        public DateOnly HireDate { get; set; }
        [DisplayName("CHỨC VỤ")]
        public string? RoleName { get; set; }

        //[InverseProperty("Employee")]
        //public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        //[InverseProperty("Employee")]
        //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        [ForeignKey("RoleId")]
        [InverseProperty("Employees")]
        public virtual RoleViewModel? Role { get; set; }

    }
}
