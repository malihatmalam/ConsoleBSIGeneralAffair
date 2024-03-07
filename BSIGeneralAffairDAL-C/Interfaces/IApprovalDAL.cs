using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IApprovalDAL
    {
        void ApprovalCMS(Approval approval);
        void ApprovalMobile(Approval approval);
        IEnumerable<Approval> GetHistoryApproval(string proposalToken);
    }
}
