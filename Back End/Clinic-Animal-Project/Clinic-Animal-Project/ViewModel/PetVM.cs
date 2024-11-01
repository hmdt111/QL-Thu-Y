using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Animal_Project.ViewModel
{
    public class PetVM
    {
        [Key]
        [Column("PetID")]
        public int PetId { get; set; }

        [StringLength(100)]
        public string? PetName { get; set; }

        [StringLength(100)]
        public string? Species { get; set; }

        [StringLength(50)]
        public string? Breed { get; set; }

        public string? MedicalHistory { get; set; }

        [StringLength(100)]
        public string? CustomerName { get; set; }
    }
}
