using BSIGeneralAffairBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IProposalDAL
    {
        IEnumerable<Proposal> GetWaitingProposal(string employeeNumber);
        void Create(Proposal newProposal, string typeProposal);
        IEnumerable<Proposal> GetHistoryProposal(string typeProposal);
        void UploadFileProposal(ProposalFile file);
        Proposal GetByProposalToken(string proposalToken);
        void Update(Proposal updateProposal);
        void Cancel(string proposalToken);
    }
}
