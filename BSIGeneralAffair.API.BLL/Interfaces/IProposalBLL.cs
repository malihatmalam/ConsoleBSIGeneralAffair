using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IProposalBLL
    {
        Task<IEnumerable<ProposalDTO>> GetHistoryProposal(string employeeNumber, string typeProposal);
        Task<ProposalDTO> GetByProposalToken(string proposalToken);
        Task<Task> Update(ProposalUpdateDTO updateProposal);
        Task<bool> Cancel(string proposalToken);
        Task<Task> Insert(ProposalCreateDTO createProposal);
        Task<IEnumerable<ProposalDTO>> GetWaitingProposal(string employeeNumber);
    }
}
