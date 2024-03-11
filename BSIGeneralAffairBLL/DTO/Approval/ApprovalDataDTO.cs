using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Approval
{
    public class ApprovalDataDTO
    {
        public string ProposalToken { get; set; }
        public string EmployeeIDNumber { get; set; }
        public string ApprovalReason { get; set; }
        public string ApprovalType { get; set; }
    }
}
