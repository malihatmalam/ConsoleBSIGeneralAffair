using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IProposalDAL
    {
        IEnumerable<Proposal> GetWaitingProposal(string employeeNumber);
        IEnumerable<Proposal> GetHistoryProposal(string typeProposal, int pageNumber, int pageSize, string search);
        void UploadFileProposal(ProposalFile file);
        Proposal GetByProposalToken(string proposalToken);
        void Update(Proposal updateProposal);
        int GetCount(string typeProposal, string search);
        IEnumerable<Proposal> GetHistoryProposal(string typeProposal);
    }
}
