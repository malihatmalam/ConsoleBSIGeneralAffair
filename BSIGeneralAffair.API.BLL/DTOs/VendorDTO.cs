using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class VendorDTO
    {
        public short VendorId { get; set; }

        public string VendorName { get; set; } = null!;

        public string? VendorAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ProposalDTO> Proposals { get; set; } = new List<ProposalDTO>();
    }
}
