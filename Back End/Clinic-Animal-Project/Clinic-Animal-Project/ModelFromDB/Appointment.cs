using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class Appointment
{
    [Key]
    [Column("AppointmentID")]
    public int AppointmentId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AppointmentDate { get; set; }

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [Column("PetID")]
    public int? PetId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column("ServiceID")]
    public int? ServiceId { get; set; }

    public string? Note { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Appointments")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Appointments")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("PetId")]
    [InverseProperty("Appointments")]
    public virtual Pet? Pet { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("Appointments")]
    public virtual Servicess? Service { get; set; }
}
