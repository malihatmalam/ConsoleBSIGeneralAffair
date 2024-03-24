using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ProposalDTO
    {
        public string ProposalToken { get; set; } = null!;
        public byte DepartementId { get; set; }
        public int UserId { get; set; }
        public short? VendorId { get; set; }
        public string ProposalObjective { get; set; } = null!;
        public string? ProposalDescription { get; set; }
        public DateTime ProposalRequireDate { get; set; }
        public decimal? ProposalBudget { get; set; }
        public string? ProposalNote { get; set; }
        public string ProposalType { get; set; } = null!;
        public string ProposalStatus { get; set; } = null!;

        public byte ProposalApproveLevel { get; set; }
        public string? ProposalNegotiationNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<ApprovalDTO> Approvals { get; set; } = new List<ApprovalDTO>();
        public virtual DepartementDTO Departement { get; set; } = null!;
        public virtual ICollection<ProposalFileDTO> ProposalFiles { get; set; } = new List<ProposalFileDTO>();
        public virtual ICollection<ProposalServiceDTO> ProposalServices { get; set; } = new List<ProposalServiceDTO>();
        public virtual UserDTO User { get; set; } = null!;
        public virtual VendorDTO? Vendor { get; set; }
    }
}
