using BSIGeneralAffair.API.Data.Helpers;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data
{
    public class UserData : IUserData
    {
        private readonly AppDbContext _context;

        private string GetConnectionString()
        {
            return DatabaseConnection.GetConnectionString();
        }

        public UserData(AppDbContext context)
        {
            _context = context;
        }
    
        public Task<Task> ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var users = await _context.Users.OrderBy(u => u.UserUsername).ToListAsync(); 
                return users;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            } 
            throw new NotImplementedException();
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                var user = await _context.Users.OrderBy(u => u.UserUsername).SingleOrDefaultAsync(u => u.UserUsername == username);
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }
                return user;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<User> Login(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = @"[Person].[USP_LoginUser]";

                    List<User> users = new List<User>();
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserUsername", username);
                    cmd.Parameters.AddWithValue("@UserPassword", password);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            User user = new User();
                            user.UserId = Convert.ToInt32(dr["UserID"]);
                            user.UserFirstName = dr["FirstName"].ToString();
                            user.UserLastName = dr["LastName"].ToString();
                            user.UserToken = dr["TokenAccess"].ToString();
                            user.UserRole = dr["RoleUser"].ToString();
                            user.Employees = new List<Employee>();
                            var employee = new Employee();
                            employee.EmployeeIdnumber = dr["EmployeeID"].ToString();
                            employee.EmployeePositionLevel = dr["LevelEmployee"].ToString();
                            employee.EmployeeJobTitle = dr["Position"].ToString();
                            user.Employees.Add(employee);

                            users.Add(user);
                        }

                    }

                    User userFirst = new User();

                    if (users.Count == 0)
                    {
                        throw new ArgumentException("Username atau Password salah");
                    }
                    else
                    {
                        userFirst = users[0];
                    }

                    return userFirst;
                }
            }
            catch (Exception ex )
            {

                throw new ArgumentException(ex.Message);
            }

            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
