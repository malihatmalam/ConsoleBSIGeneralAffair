using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IApprovalData
    {
        Task<Task> Approval(Approval approval);
        Task<IEnumerable<Approval>> GetHistoryApproval(string proposalToken);
    }
}
