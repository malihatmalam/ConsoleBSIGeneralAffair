using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class ProposalFile
    {
        public ProposalFile() {
            this.Proposal = new Proposal();
        }
        public int? ProposalFileID { get; set; }
        public string ProposalToken { get; set; }
        public string ProposalFilePath { get; set; }
        public string ProposalFileType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Proposal Proposal { get; set; }
    }

}
