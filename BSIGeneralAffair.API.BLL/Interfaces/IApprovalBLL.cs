using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IApprovalBLL
    {
        Task<Task> Approval(ApprovalCreateDTO approval);
        Task<IEnumerable<ApprovalDTO>> GetHistoryApproval(string proposalToken);
    }
}
