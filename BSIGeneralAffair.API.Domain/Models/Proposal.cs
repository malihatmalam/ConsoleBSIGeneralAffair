using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Proposals", Schema = "GeneralAffair")]
[Index("ProposalApproveLevel", Name = "Index_ProposalApproveLevel")]
[Index("ProposalStatus", Name = "Index_ProposalStatus")]
public partial class Proposal
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string ProposalToken { get; set; } = null!;

    [Column("DepartementID")]
    public byte DepartementId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("VendorID")]
    public short? VendorId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string ProposalObjective { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? ProposalDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ProposalRequireDate { get; set; }

    [Column(TypeName = "money")]
    public decimal? ProposalBudget { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ProposalNote { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string ProposalType { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ProposalStatus { get; set; } = null!;

    public byte ProposalApproveLevel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ProposalNegotiationNote { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("ProposalTokenNavigation")]
    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    [ForeignKey("DepartementId")]
    [InverseProperty("Proposals")]
    public virtual Departement Departement { get; set; } = null!;

    [InverseProperty("ProposalTokenNavigation")]
    public virtual ICollection<ProposalFile> ProposalFiles { get; set; } = new List<ProposalFile>();

    [InverseProperty("ProposalTokenNavigation")]
    public virtual ICollection<ProposalService> ProposalServices { get; set; } = new List<ProposalService>();

    [ForeignKey("UserId")]
    [InverseProperty("Proposals")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("Proposals")]
    public virtual Vendor? Vendor { get; set; }
}
