using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Assets", Schema = "GeneralAffair")]
[Index("AsssetName", Name = "Index_AssetName")]
[Index("AssetProcurementDate", Name = "Index_AssetProcurementDate")]
[Index("AssetNumber", Name = "Unique_AssetNumber", IsUnique = true)]
public partial class Asset
{
    [Key]
    [Column("AssetID")]
    public int AssetId { get; set; }

    [Column("BrandID")]
    public short BrandId { get; set; }

    [Column("AssetCategoryID")]
    public short AssetCategoryId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AssetFactoryNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AssetNumber { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string AsssetName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? AssetCost { get; set; }

    public DateTime AssetProcurementDate { get; set; }

    public bool AssetFlagActive { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string AssetCondition { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("AssetCategoryId")]
    [InverseProperty("Assets")]
    public virtual AssetCategory AssetCategory { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<AssetUser> AssetUsers { get; set; } = new List<AssetUser>();

    [ForeignKey("BrandId")]
    [InverseProperty("Assets")]
    public virtual Brand Brand { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<ProposalService> ProposalServices { get; set; } = new List<ProposalService>();
}
