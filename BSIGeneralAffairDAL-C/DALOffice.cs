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
    public class DALOffice : IOfficeDAL
    {
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[Office].[USP_DeleteOffice]";
                var param = new { OfficeID = id };
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
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Office> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[Office].[USP_SelectAllOffice]";

                var results = conn.Query<Office>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Office GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [Office].[OfficeLocation] Where [OfficeID] = @OfficeID ";
                var param = new { OfficeID = id };
                var result = conn.QuerySingleOrDefault<Office>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Office> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [Office].[OfficeLocation] Where [OfficeName] = @OfficeName ";
                var param = new { OfficeName = name };
                var result = conn.Query<Office>(strSql, param);
                return result;
            }
        }

        public int GetCountOffices(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [Office].[OfficeLocation] Where [OfficeName] like @OfficeName ";
                var param = new { OfficeName = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<Office> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [Office].[OfficeLocation] 
                              Where [OfficeName] like @OfficeName 
                              order by OfficeName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { OfficeName = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<Office>(strSql, param);
                return results;
            }
        }

        public void Insert(Office entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[Office].[USP_StoreOffice]";
                var param = new { 
                    OfficeName = entity.OfficeName,
                    OfficeAddress = entity.OfficeAddress,
                    OfficeFlagActive = entity.OfficeFlagActive
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

        public void Update(Office entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[Office].[USP_UpdateOffice]";
                    var param = new
                    {
                        OfficeID = entity.OfficeID,
                        OfficeName = entity.OfficeName,
                        OfficeAddress = entity.OfficeAddress,
                        OfficeFlagActive = entity.OfficeFlagActive
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
