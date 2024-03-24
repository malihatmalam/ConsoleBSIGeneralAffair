using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;


[Table("Brands", Schema = "GeneralAffair")]
[Index("BrandName", Name = "Unique_BrandName", IsUnique = true)]
public partial class Brand
{
    [Key]
    [Column("BrandID")]
    public short BrandId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string BrandName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Brand")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
