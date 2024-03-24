using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class OfficeLocationDTO
    {
        public byte OfficeId { get; set; }
        public string OfficeName { get; set; } = null!;
        public string? OfficeAddress { get; set; }

        public bool OfficeFlagActive { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
