using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; } = null!;

        public string? UserLastName { get; set; }

        public string UserUsername { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string? UserToken { get; set; }

        public string UserRole { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ApprovalDTO> Approvals { get; set; } = new List<ApprovalDTO>();

        public virtual ICollection<AssetUserDTO> AssetUsers { get; set; } = new List<AssetUserDTO>();

        public virtual ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public virtual ICollection<ProposalDTO> Proposals { get; set; } = new List<ProposalDTO>();
    }
}
