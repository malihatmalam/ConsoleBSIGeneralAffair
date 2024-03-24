using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class EmployeeDTO
    {
        public string EmployeeIdnumber { get; set; } = null!;
        public int UserId { get; set; }
        public byte DepartementId { get; set; }
        public byte OfficeId { get; set; }
        public string EmployeePositionLevel { get; set; } = null!;
        public string EmployeeJobTitle { get; set; } = null!;
        public string EmployeeGender { get; set; } = null!;
        public string EmployeeMaritalStatus { get; set; } = null!;

        public DateOnly? EmployeeBirthDate { get; set; }

        public DateOnly EmployeeHireDate { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual DepartementDTO Departement { get; set; } = null!;
        public virtual OfficeLocationDTO Office { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
