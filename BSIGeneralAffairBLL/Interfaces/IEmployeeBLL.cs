using BSIGeneralAffairBLL.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IEmployeeBLL
    {
        IEnumerable<EmployeeListDTO> GetAll();
        void Insert(EmployeeCreateDTO newEmployee);
        EmployeeListDTO GetByEmployeeID(int employeeID);
        IEnumerable<EmployeeListDTO> GetByName(string name);
        IEnumerable<EmployeeListDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountEmployee(string name);
    }
}
