using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ApprovalDTO
    {
        public string? EmployeeIDNumber { get; set; }
        public string? ApproverName { get; set; }
        public string? ApproverPosition { get; set; }
        public int ApprovalId { get; set; }
        public string ProposalToken { get; set; } = null!;
        public int ApprovalUserId { get; set; }
        public string ApprovalStatus { get; set; } = null!;
        public string? ApprovalReason { get; set; }

        public byte ApprovalLevel { get; set; }
        public DateTime ApprovalAt { get; set; }
        public virtual UserDTO ApprovalUser { get; set; } = null!;
        public virtual ProposalDTO ProposalTokenNavigation { get; set; }
    }
}
