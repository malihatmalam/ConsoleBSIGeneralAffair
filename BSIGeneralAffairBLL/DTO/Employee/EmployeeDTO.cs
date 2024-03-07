using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.DTO.Office;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Employee
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            this.Department = new DepartementDTO();
            this.User = new UserDTO();
            this.Office = new OfficeDTO();
        }
        public string EmployeeIDNumber { get; set; }
        public int? UserID { get; set; }
        public byte? DepartementID { get; set; }
        public byte? OfficeID { get; set; }
        public string EmployeePositionLevel { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeJobTitle { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public string EmployeeBirthDate { get; set; }
        public string EmployeeHireDate { get; set; }
        public string EmployeeType { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public string UpdatedAt { get; set; }
        public UserDTO User { get; set; }
        public DepartementDTO Department { get; set; }
        public OfficeDTO Office { get; set; }
    }
}
