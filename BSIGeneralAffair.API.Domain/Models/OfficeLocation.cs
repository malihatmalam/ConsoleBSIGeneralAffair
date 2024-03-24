using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("OfficeLocation", Schema = "Office")]
public partial class OfficeLocation
{
    [Key]
    [Column("OfficeID")]
    public byte OfficeId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string OfficeName { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string? OfficeAddress { get; set; }

    public bool OfficeFlagActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [InverseProperty("Office")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
