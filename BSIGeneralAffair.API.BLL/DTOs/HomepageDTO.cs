using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class HomepageDTO
    {
        public int procurementProposal { get; set; } = 0;
        public int serviceProposal { get; set;  } = 0;
        public int completedProposal { get; set; } = 0;
        public int rejectProposal { get; set; } = 0;
        public int waitingProposal { get; set; } = 0;
    }
}
