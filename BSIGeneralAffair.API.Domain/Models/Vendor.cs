using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Vendors", Schema = "GeneralAffair")]
[Index("VendorName", Name = "Unique_VendorName", IsUnique = true)]
public partial class Vendor
{
    [Key]
    [Column("VendorID")]
    public short VendorId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string VendorName { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string? VendorAddress { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Vendor")]
    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
