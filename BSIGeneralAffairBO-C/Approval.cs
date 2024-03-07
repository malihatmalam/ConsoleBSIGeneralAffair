using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Approval
    {
        public int? ApprovalID { get; set; }
        public string ProposalToken { get; set; }
        public string EmployeeIDNumber { get; set; }
        public int? ApprovalUserID { get; set; }
        public string ApprovalStatus { get; set; } // Approval Type, Ex: Approve / Reject
        public string ApprovalReason { get; set; }
        public byte? ApprovalLevel { get; set; }
        public DateTime? ApprovalAt { get; set; }
    }
}
