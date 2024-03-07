using BSIGeneralAffairBLL.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.User
{
    public class UserDTO
    {
        public int? UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserToken { get; set; }
        public string UserRole { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public EmployeeDTO Employee { get; set; }
    }

}
