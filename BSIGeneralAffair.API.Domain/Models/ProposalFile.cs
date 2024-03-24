using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("ProposalFiles", Schema = "GeneralAffair")]
[Index("ProposalFileType", Name = "Index_ProposalFilesType")]
public partial class ProposalFile
{
    [Key]
    [Column("ProposalFileID")]
    public int ProposalFileId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProposalToken { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ProposalFilePath { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ProposalFileType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("ProposalToken")]
    [InverseProperty("ProposalFiles")]
    public virtual Proposal ProposalTokenNavigation { get; set; } = null!;
}
