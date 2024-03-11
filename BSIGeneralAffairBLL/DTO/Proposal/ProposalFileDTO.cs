using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Proposal
{
    public class ProposalFileDTO
    {
        //public ProposalFileDTO()
        //{
        //    this.Proposal = new ProposalDTO();
        //}
        public int? ProposalFileID { get; set; }
        public string ProposalToken { get; set; }
        public string ProposalFilePath { get; set; }
        public string ProposalFileType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ProposalDTO Proposal { get; set; }
    }
}
