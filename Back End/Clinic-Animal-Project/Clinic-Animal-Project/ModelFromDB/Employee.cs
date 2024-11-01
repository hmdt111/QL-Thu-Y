using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Animal_Project.ModelFromDB;

public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(100)]
    public string? EmployeeName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EmployeeEmail { get; set; }

    public DateOnly? HireDate { get; set; }

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    [InverseProperty("Employee")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual Role? Role { get; set; }
}
