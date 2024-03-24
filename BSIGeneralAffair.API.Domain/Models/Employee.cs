using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Employees", Schema = "HumanResource")]
[Index("EmployeeHireDate", Name = "Index_EmployeeHireDate")]
[Index("EmployeePositionLevel", Name = "Index_EmployeeIDNumber")]
public partial class Employee
{
    [Key]
    [Column("EmployeeIDNumber")]
    [StringLength(5)]
    public string EmployeeIdnumber { get; set; } = null!;

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("DepartementID")]
    public byte DepartementId { get; set; }

    [Column("OfficeID")]
    public byte OfficeId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string EmployeePositionLevel { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string EmployeeJobTitle { get; set; } = null!;

    [StringLength(1)]
    public string EmployeeGender { get; set; } = null!;

    [StringLength(1)]
    public string EmployeeMaritalStatus { get; set; } = null!;

    public DateOnly? EmployeeBirthDate { get; set; }

    public DateOnly EmployeeHireDate { get; set; }

    [Column(TypeName = "money")]
    public decimal? EmployeeSalary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DepartementId")]
    [InverseProperty("Employees")]
    public virtual Departement Departement { get; set; } = null!;

    [ForeignKey("OfficeId")]
    [InverseProperty("Employees")]
    public virtual OfficeLocation Office { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Employees")]
    public virtual User User { get; set; } = null!;
}
