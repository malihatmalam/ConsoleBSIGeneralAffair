using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;


[Table("AssetCategories", Schema = "GeneralAffair")]
[Index("AssetCategoryName", Name = "Index_AssetCatgoriesName")]
public partial class AssetCategory
{
    [Key]
    [Column("AssetCategoryID")]
    public short AssetCategoryId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string AssetCategoryName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("AssetCategory")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
