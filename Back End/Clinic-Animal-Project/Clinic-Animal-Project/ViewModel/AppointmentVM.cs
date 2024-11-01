using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Animal_Project.ViewModel
{
    public class AppointmentVM
    {
        [Key]
        [Column("AppointmentID")]
        public int AppointmentId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? AppointmentDate { get; set; }

        [StringLength(100)]
        public string? CustomerName { get; set; }
        [StringLength(100)]
        public string? PetName { get; set; }

        [StringLength(100)]
        public string? EmployeeName { get; set; }

        [StringLength(100)]
        public string? ServiceName { get; set; }

        public string? Note { get; set; }
    }
}
