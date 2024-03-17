using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using static Dapper.SqlMapper;

namespace BSIGeneralAffairDAL_C
{
    public class DALEmployee : IEmployeeDAL

    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[HumanResource].[USP_CreateEmployee]";
                var param = new {
                    Firstname = employee.User.UserFirstName,
                    LastName = employee.User.UserLastName,
                    EmployeeNumber = employee.EmployeeIDNumber,
                    DepartementID = employee.Department.DepartementID,
                    OfficeID = employee.Office.OfficeID,
                    EmployeePositionLevel = employee.EmployeePositionLevel,
                    EmployeeJobTitle = employee.EmployeeJobTitle,
                    EmployeeGender = employee.EmployeeGender,
                    EmployeeMaritalStatus = employee.EmployeeMaritalStatus,
                    EmployeeBirthDate = employee.EmployeeBirthDate,
                    EmployeeHireDate = employee.EmployeeHireDate,
                    EmployeeType = employee.EmployeeType,
                    EmployeeSalary = employee.EmployeeSalary };
                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result == 1)
                    {
                        throw new ArgumentException("Insert data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public IEnumerable<EmployeeList> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[HumanResource].[USP_ListEmployee]";

                var results = conn.Query<EmployeeList>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public void Update(Employee employeeUpdate)
        {
            throw new NotImplementedException();
        }

        public EmployeeList GetById(int employeeNumberid)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[HumanResource].[USP_ListEmployeeByID]";
                var param = new { EmployeeIDNumber = employeeNumberid };
                var result = conn.QuerySingleOrDefault<EmployeeList>(strSql, param);
                return result;
            }
        }

        public IEnumerable<EmployeeList> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[HumanResource].[USP_ListEmployeeByName]";
                var param = new { Fullname = name };
                var result = conn.Query<EmployeeList>(strSql, param);
                return result;
            }
        }

        public int GetCountEmployee(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[HumanResource].[USP_CountEmployeeByName]";
                var param = new { Fullname = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<EmployeeList> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[HumanResource].[USP_PaginationEmployeeByName]";
                var param = new { Fullname = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<EmployeeList>(strSql, param);
                return results;
            }
        }
    }
}
