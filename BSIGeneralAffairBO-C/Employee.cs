using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Employee
    {
        //public Employee() {
        //    this.User = new User();
        //    this.Department = new Departement();
        //    this.Office = new Office();
        //}   
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
        public User User { get; set; }
        public Departement Department { get; set; }
        public Office Office { get; set; }
    }

}
