using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Approvals", Schema = "GeneralAffair")]
public partial class Approval
{
    public string? EmployeeIDNumber { get; set; }
    public string? ApproverName { get; set; }
    public string? ApproverPosition { get; set; }

    [Key]
    [Column("ApprovalID")]
    public int ApprovalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProposalToken { get; set; } = null!;

    [Column("ApprovalUserID")]
    public int ApprovalUserId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string ApprovalStatus { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? ApprovalReason { get; set; }

    public byte ApprovalLevel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ApprovalAt { get; set; }

    [ForeignKey("ApprovalUserId")]
    [InverseProperty("Approvals")]
    public virtual User ApprovalUser { get; set; } = null!;

    [ForeignKey("ProposalToken")]
    [InverseProperty("Approvals")]
    public virtual Proposal ProposalTokenNavigation { get; set; } = null!;
}
