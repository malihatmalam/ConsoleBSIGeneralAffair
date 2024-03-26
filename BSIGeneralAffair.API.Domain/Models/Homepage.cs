using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Domain.Models
{
    public class Homepage
    {
        public int procurementProposal {  get; set; } = 0;
        public int serviceProposal { get; set; } = 0;
        public int completedProposal { get; set; } = 0;
        public int rejectProposal { get; set; } = 0;
        public int waitingProposal { get; set; } = 0;
    }
}
