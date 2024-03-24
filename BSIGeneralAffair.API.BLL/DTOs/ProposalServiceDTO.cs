using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class ProposalServiceDTO
    {
        public int ProposalServiceId { get; set; }

        public string ProposalToken { get; set; } = null!;

        public int AssetId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual AssetDTO Asset { get; set; } = null!;

        public virtual ProposalDTO ProposalTokenNavigation { get; set; } = null!;
    }
}
