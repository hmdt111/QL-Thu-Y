using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class Medication
{
    [Key]
    [Column("MedicationID")]
    public int MedicationId { get; set; }

    [StringLength(100)]
    public string? MedicationName { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? UnitPrice { get; set; }

    public int? StockQuantity { get; set; }

    public string? MedicationDescription { get; set; }

    [InverseProperty("Medication")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
