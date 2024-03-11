using BSIGeneralAffairBLL.DTO.Approval;
using BSIGeneralAffairBLL.DTO.Proposal;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class ApprovalBLL : IApprovalBLL
    {
        private readonly IApprovalDAL _approvalDAL;

        public ApprovalBLL() 
        {
            _approvalDAL = new DALApproval();
        }

        public void ApprovalCMS(ApprovalDataDTO approval)
        {
            if (string.IsNullOrEmpty(approval.ProposalToken.ToString()))
            {
                throw new ArgumentException("Proposal token is required");
            }
            if (string.IsNullOrEmpty(approval.EmployeeIDNumber.ToString()))
            {
                throw new ArgumentException("Employee number is required");
            }
            if (string.IsNullOrEmpty(approval.ApprovalType.ToString()))
            {
                throw new ArgumentException("Type approval is required");
            }
            if (string.IsNullOrEmpty(approval.ApprovalReason.ToString()))
            {
                throw new ArgumentException("Reason is required");
            }

            try
            {

                var approvalDTO = new BSIGeneralAffairBO_C.Approval
                {
                    ProposalToken = approval.ProposalToken,
                    EmployeeIDNumber = approval.EmployeeIDNumber,
                    ApprovalReason = approval.ApprovalReason,
                    ApprovalStatus = approval.ApprovalType
                };
                _approvalDAL.ApprovalCMS(approvalDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void ApprovalMobile(ApprovalDataDTO approval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApprovalDTO> GetHistoryApproval(string proposalToken)
        {
            List<ApprovalDTO> listApprovalDTOs = new List<ApprovalDTO>();
            var approvals = _approvalDAL.GetHistoryApproval(proposalToken);
            foreach (var approval in approvals)
            {
                ApprovalDTO approvalDTO = new ApprovalDTO();
                approvalDTO.ApproverName = approval.ApproverName;
                approvalDTO.ApprovalStatus = approval.ApprovalStatus;
                approvalDTO.ApproverPosition = approval.ApproverPosition;
                approvalDTO.ApprovalReason = approval.ApprovalReason;
                approvalDTO.ApprovalAt = approval.ApprovalAt;
                listApprovalDTOs.Add(approvalDTO);
            }
            return listApprovalDTOs;
        }
    }
}
