using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("ProposalServices", Schema = "GeneralAffair")]
public partial class ProposalService
{
    [Key]
    [Column("ProposalServiceID")]
    public int ProposalServiceId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProposalToken { get; set; } = null!;

    [Column("AssetID")]
    public int AssetId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("ProposalServices")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("ProposalToken")]
    [InverseProperty("ProposalServices")]
    public virtual Proposal ProposalTokenNavigation { get; set; } = null!;
}
