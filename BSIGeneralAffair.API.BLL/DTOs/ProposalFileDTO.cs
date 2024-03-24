using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ProposalFileDTO
    {
        public int ProposalFileId { get; set; }

        public string ProposalToken { get; set; } = null!;

        public string ProposalFilePath { get; set; } = null!;

        public string ProposalFileType { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public virtual ProposalDTO ProposalTokenNavigation { get; set; } = null!;
    }
}
