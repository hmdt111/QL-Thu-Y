using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Animal_Project.ViewModel
{
    public class AccountVM
    {
        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? Username { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? Pass { get; set; }

        [StringLength(100)]
        public string? EmployeeName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
    }
}
