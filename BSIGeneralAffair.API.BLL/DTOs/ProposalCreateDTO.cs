using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ProposalCreateDTO
    {
        public string EmployeeIdnumber { get; set; } = null!;
        public string? AssetNumber { get; set; } = null!;
        public string ProposalObjective { get; set; } = null!;
        public string? ProposalDescription { get; set; }
        public DateTime ProposalRequireDate { get; set; }
        public decimal? ProposalBudget { get; set; }
        public string? ProposalNote { get; set; }
        public string? ProposalType { get; set; } = null!;
    }
}
