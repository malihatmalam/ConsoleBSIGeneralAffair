using BSIGeneralAffairBLL.DTO.Approval;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IApprovalBLL
    {
        void ApprovalCMS(ApprovalDataDTO approval);
        void ApprovalMobile(ApprovalDataDTO approval);
        IEnumerable<ApprovalDTO> GetHistoryApproval(string proposalToken);
    }
}
