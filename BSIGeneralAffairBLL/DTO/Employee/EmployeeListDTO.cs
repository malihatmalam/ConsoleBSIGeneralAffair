using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Employee
{
    public class EmployeeListDTO
    {
        public string EmployeeID { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Office { get; set; }
        public string HireDate { get; set; }
    }
}
