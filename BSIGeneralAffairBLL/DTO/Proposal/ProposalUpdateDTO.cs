using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Proposal
{
    public class ProposalUpdateDTO
    {
        public string ProposalToken { get; set; }
        public int? VendorID { get; set; }
        public string ProposalObjective { get; set; }
        public string ProposalDescription { get; set; }
        public string ProposalRequireDate { get; set; }
        public int ProposalBudget { get; set; }
        public string ProposalNote { get; set; }
        public string ProposalNegotiationNote { get; set; }
    }
}
