using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;


[Table("Departements", Schema = "HumanResource")]
public partial class Departement
{
    [Key]
    [Column("DepartementID")]
    public byte DepartementId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string DepartementName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Departement")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Departement")]
    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
