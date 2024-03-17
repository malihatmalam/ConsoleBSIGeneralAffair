using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IEmployeeDAL
    {
        EmployeeList GetById(int id);
        IEnumerable<EmployeeList> GetAll();
        void Create(Employee employee);
        void Update(Employee employeeUpdate);
        IEnumerable<EmployeeList> GetByName(string name);
        int GetCountEmployee(string name);
        IEnumerable<EmployeeList> GetWithPaging(int pageNumber, int pageSize, string name);
    }
}
