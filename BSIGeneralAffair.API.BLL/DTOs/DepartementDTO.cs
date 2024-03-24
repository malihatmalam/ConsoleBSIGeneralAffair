using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class DepartementDTO
    {
        public byte DepartementId { get; set; }
        public string DepartementName { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
        public virtual ICollection<ProposalDTO> Proposals { get; set; } = new List<ProposalDTO>();
    }
}
