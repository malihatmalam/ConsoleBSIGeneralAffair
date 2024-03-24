using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ApprovalCreateDTO
    {

        public string ProposalToken { get; set; } = string.Empty;
        public string? EmployeeIDNumber { get; set; }
        public string? ApprovalReason { get; set; }
        public string ApprovalStatus { get; set; } = null!;

    }
}
