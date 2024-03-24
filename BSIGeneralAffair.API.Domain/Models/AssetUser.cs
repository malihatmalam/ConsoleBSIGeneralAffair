using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;


[Table("AssetUsers", Schema = "GeneralAffair")]
public partial class AssetUser
{
    [Key]
    [Column("AssetUserID")]
    public int AssetUserId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("AssetID")]
    public int AssetId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime HandoverDateTime { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? HandoverFilePath { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("AssetUsers")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AssetUsers")]
    public virtual User User { get; set; } = null!;
}
