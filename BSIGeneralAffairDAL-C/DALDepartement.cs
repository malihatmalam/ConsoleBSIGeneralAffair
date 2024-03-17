using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace BSIGeneralAffairDAL_C
{
    public class DALDepartement : IDepartementDAL
    {
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[HumanResource].[USP_DeleteDepartement]";
                var param = new { DepartementID = id };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result == 1)
                    {
                        throw new ArgumentException("Delete data failed..");
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

        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Departement> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[HumanResource].[USP_SelectAllDepartement]";

                var results = conn.Query<Departement>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Departement GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [HumanResource].[Departements] Where [DepartementID] = @DepartementID ";
                var param = new { DepartementID = id };
                var result = conn.QuerySingleOrDefault<Departement>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Departement> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [HumanResource].[Departements] Where [DepartementName] = @DepartementName ";
                var param = new { DepartementName = name };
                var result = conn.Query<Departement>(strSql, param);
                return result;
            }
        }

        public int GetCountDepartment(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [HumanResource].[Departements] Where [DepartementName] like @DepartementName ";
                var param = new { DepartementName = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<Departement> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [HumanResource].[Departements]
                              Where [DepartementName] like @DepartementName
                              order by DepartementName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { DepartementName = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<Departement>(strSql, param);
                return results;
            }
        }

        public void Insert(Departement entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[HumanResource].[USP_StoreDepartement]";
                var param = new
                {
                    DepartementName = entity.DepartementName
                };
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

        public void Update(Departement entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[HumanResource].[USP_UpdateDepartement]";
                    var param = new
                    {
                        DepartementID = entity.DepartementID,
                        DepartementName = entity.DepartementName
                    };
                    int result = conn.Execute(strSql, param);

                    //jika result = -1, berarti update data gagal
                    if (result == 1)
                    {
                        throw new Exception("Update data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
