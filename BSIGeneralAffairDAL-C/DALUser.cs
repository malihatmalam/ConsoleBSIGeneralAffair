using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using GeneralAffairInterface;

namespace BSIGeneralAffairDAL_C
{
    public class DALUser : IUserDAL
    {
        public User GetByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from [Person].[Users] where [UserUsername] = @UserUsername";
                var param = new { UserUsername = username };
                var result = conn.QueryFirstOrDefault<User>(strSql, param);
                return result;
            }
        }

        public User Login(string username, string password)
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
                        user.UserID = Convert.ToInt32(dr["UserID"]);
                        user.UserFirstName = dr["FirstName"].ToString();
                        user.UserLastName = dr["LastName"].ToString();
                        user.UserToken = dr["TokenAccess"].ToString();
                        user.UserRole = dr["RoleUser"].ToString();
                        user.Employee = new Employee();
                        user.Employee.EmployeeIDNumber = dr["EmployeeID"].ToString();
                        user.Employee.EmployeePositionLevel = dr["LevelEmployee"].ToString();
                        user.Employee.EmployeeJobTitle = dr["Position"].ToString();

                        users.Add(user);
                    }
                    
                }

                User userFirst = new User();

                if (users.Count == 0)
                {
                    throw new ArgumentException("Username atau Password salah");
                }
                else {
                    userFirst = users[0];
                }

                return userFirst;
            }

        }

        public IEnumerable<User> GetAll() {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from [Person].[Users] order by [UserUsername]";
                var results = conn.Query<User>(strSql);
                return results;
            }
        }

        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
    }
}
