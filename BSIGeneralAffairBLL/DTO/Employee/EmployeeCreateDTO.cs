using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Employee
{
    public class EmployeeCreateDTO
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public int DepartementID { get; set; }
        public int OfficeID { get; set; }
        public string EmployeePositionLevel {  get; set; }
        public string EmployeeJobTitle { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public string EmployeeBirthDate { get; set; }
        public string EmployeeHireDate { get; set; }
        public string EmployeeType { get; set; }
        public decimal? EmployeeSalary { get; set; }
    }
}
