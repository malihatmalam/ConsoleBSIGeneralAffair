using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ProposalUpdateDTO
    {
        public string ProposalToken { get; set; } = null!;
        public short? VendorId { get; set; } = null!;
        public string ProposalObjective { get; set; } = null!;
        public string? ProposalDescription { get; set; }
        public DateTime ProposalRequireDate { get; set; }
        public decimal? ProposalBudget { get; set; }
        public string? ProposalNote { get; set; }
        public string? ProposalNegotiationNote { get; set; }
    }
}
