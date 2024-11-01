using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class InvoiceDetail
{
    [Key]
    [Column("InvoiceDetailID")]
    public int InvoiceDetailId { get; set; }

    [Column("InvoiceID")]
    public int? InvoiceId { get; set; }

    [Column("PetID")]
    public int? PetId { get; set; }

    [Column("MedicationID")]
    public int? MedicationId { get; set; }

    [Column("ServiceID")]
    public int? ServiceId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SubTotal { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Invoice? Invoice { get; set; }

    [ForeignKey("MedicationId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Medication? Medication { get; set; }

    [ForeignKey("PetId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Pet? Pet { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Servicess? Service { get; set; }
}
