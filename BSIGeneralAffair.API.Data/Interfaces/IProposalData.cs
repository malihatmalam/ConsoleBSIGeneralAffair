using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IProposalData
    {
        Task<IEnumerable<Proposal>> GetHistoryProposal(string employeeNumber, string typeProposal);
        Task<Proposal> GetByProposalToken(string proposalToken);
        Task<Task> Update(Proposal updateProposal);
        Task<Task> Create(Proposal createProposal, string employeeNumber, string typeProposal, string? assetNumber);
        Task<bool> Cancel(string proposalToken);
        Task<IEnumerable<Proposal>> GetWaitingProposal(string employeeNumber);
    }
}
