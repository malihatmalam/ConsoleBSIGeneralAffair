using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class ProposalService
    {
        public ProposalService() {
           this.Proposal = new Proposal();
        }
        public int? ProposalServiceID { get; set; }
        public string ProposalToken { get; set; }
        public int? AssetID { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Proposal Proposal { get; set; }
    }

}
