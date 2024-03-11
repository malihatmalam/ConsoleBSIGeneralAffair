using BSIGeneralAffairBLL.DTO.Proposal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IProposalBLL
    {
        IEnumerable<ProposalDTO> GetWaitingProposal(string employeeNumber);
        IEnumerable<ProposalDTO> GetHistoryProposal(string typeProposal, int pageNumber, int pageSize, string search);
        void UploadFileProposal(ProposalFileDTO file);
        ProposalDTO GetByProposalToken(string proposalToken);
        void Update(ProposalUpdateDTO updateProposal);
        int GetCount(string typeProposal, string search);
    }
}
