using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Approval
{
    public class ApprovalDTO
    {
        public int? ApprovalID { get; set; }
        public string ProposalToken { get; set; }
        public string EmployeeIDNumber { get; set; }
        public int? ApprovalUserID { get; set; }
        public string ApproverName { get; set; }
        public string ApproverPosition { get; set; }
        public string ApprovalStatus { get; set; } // Approval Type, Ex: Approve / Reject
        public string ApprovalReason { get; set; }
        public byte? ApprovalLevel { get; set; }
        public string ApprovalAt { get; set; }
    }
}
