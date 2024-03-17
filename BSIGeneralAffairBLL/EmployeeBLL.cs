using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.DTO.Employee;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using GeneralAffairInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeDAL _employeeDAL;

        public EmployeeBLL() {
            _employeeDAL = new DALEmployee();
        }

        public IEnumerable<EmployeeListDTO> GetAll()
        {
            List<EmployeeListDTO> listEmployiesDTO = new List<EmployeeListDTO>();
            var employies = _employeeDAL.GetAll();
            foreach (var employee in employies)
            {
                listEmployiesDTO.Add(new EmployeeListDTO
                {
                    EmployeeID = employee.EmployeeID,
                    Fullname = employee.Fullname,
                    Department = employee.Department,
                    Office = employee.Office,
                    Position = employee.Position,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate
                });
            }
            return listEmployiesDTO;
        }

        public EmployeeListDTO GetByEmployeeID(int employeeID)
        {
            EmployeeListDTO employeeDTO = new EmployeeListDTO();
            var employee = _employeeDAL.GetById(employeeID);
            if (employee != null)
            {
                employeeDTO.EmployeeID = employee.EmployeeID;
                employeeDTO.Fullname = employee.Fullname;
                employeeDTO.Department = employee.Department;
                employeeDTO.Office = employee.Office;
                employeeDTO.Position = employee.Position;
                employeeDTO.Gender = employee.Gender;
                employeeDTO.HireDate = employee.HireDate;
            }
            //else
            //{
            //    throw new ArgumentException($"Employee {employeeID} not found");
            //}
            return employeeDTO;
        }

        public IEnumerable<EmployeeListDTO> GetByName(string name)
        {
            var employies = _employeeDAL.GetByName(name);

            List<EmployeeListDTO> listEmployieeDTOs = new List<EmployeeListDTO>();
            foreach (var employee in employies)
            {
                listEmployieeDTOs.Add(new EmployeeListDTO
                {
                    EmployeeID = employee.EmployeeID,
                    Fullname = employee.Fullname,
                    Department = employee.Department,
                    Office = employee.Office,
                    Position = employee.Position,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate
                });
            }
            return listEmployieeDTOs;
        }

        public int GetCountEmployee(string name)
        {
            return _employeeDAL.GetCountEmployee(name);
        }

        public IEnumerable<EmployeeListDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<EmployeeListDTO> listEmployeiesDTO = new List<EmployeeListDTO>();
            var employies = _employeeDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var employee in employies)
            {
                listEmployeiesDTO.Add(new EmployeeListDTO
                {
                    EmployeeID = employee.EmployeeID,
                    Fullname = employee.Fullname,
                    Department = employee.Department,
                    Office = employee.Office,
                    Position = employee.Position,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate
                });

            }
            return listEmployeiesDTO;
        }

        public void Insert(EmployeeCreateDTO newEmployee)
        {
            if (string.IsNullOrEmpty(newEmployee.Firstname))
            {
                throw new ArgumentException("Fistname is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeNumber))
            {
                throw new ArgumentException("Employee number is required");
            }
            if (string.IsNullOrEmpty(newEmployee.DepartementID.ToString()))
            {
                throw new ArgumentException("Department is required");
            }
            if (string.IsNullOrEmpty(newEmployee.OfficeID.ToString()))
            {
                throw new ArgumentException("Office is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeePositionLevel))
            {
                throw new ArgumentException("Level employee is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeJobTitle))
            {
                throw new ArgumentException("Position employee is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeGender))
            {
                throw new ArgumentException("Gender is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeMaritalStatus))
            {
                throw new ArgumentException("Marital status is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeHireDate))
            {
                throw new ArgumentException("Hire Date status is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeType))
            {
                throw new ArgumentException("Employee type is required");
            }
            if (string.IsNullOrEmpty(newEmployee.EmployeeSalary.ToString()))
            {
                throw new ArgumentException("Salary employee is required");
            }
            else if (newEmployee.EmployeeNumber.Length > 5)
            {
                throw new ArgumentException("Employee number max length is 5 character");
            }

            try
            {
                var employeeDTO = new Employee
                {
                    EmployeeIDNumber = newEmployee.EmployeeNumber.ToString(),
                    EmployeePositionLevel = newEmployee.EmployeePositionLevel,
                    EmployeeJobTitle = newEmployee.EmployeeJobTitle,
                    EmployeeGender = newEmployee.EmployeeGender,
                    EmployeeMaritalStatus = newEmployee.EmployeeMaritalStatus,
                    EmployeeBirthDate = newEmployee.EmployeeBirthDate,
                    EmployeeHireDate = newEmployee.EmployeeHireDate,
                    EmployeeType = newEmployee.EmployeeType,
                    EmployeeSalary = newEmployee.EmployeeSalary
                };
                employeeDTO.User = new User();
                employeeDTO.Department = new Departement();
                employeeDTO.Office = new Office();
                employeeDTO.User.UserFirstName = newEmployee.Firstname;
                employeeDTO.User.UserLastName = newEmployee.LastName;
                employeeDTO.Department.DepartementID = newEmployee.DepartementID;
                employeeDTO.Office.OfficeID = newEmployee.OfficeID;
                _employeeDAL.Create(employeeDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
