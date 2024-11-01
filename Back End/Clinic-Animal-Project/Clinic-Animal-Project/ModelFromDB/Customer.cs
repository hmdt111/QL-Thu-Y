using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class Customer
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(100)]
    public string? CustomerName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public string? CustomerAddress { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CustomerEmail { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("Customer")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [InverseProperty("Customer")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
