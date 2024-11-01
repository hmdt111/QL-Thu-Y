using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class Pet
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

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [InverseProperty("Pet")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Pets")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Pet")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
