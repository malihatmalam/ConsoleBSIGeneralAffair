
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
    public class DALVendor : IVendorDAL
    {
        public void Insert(Vendor entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[GeneralAffair].[USP_StoreVendor]";
                var param = new { 
                    VendorName = entity.VendorName, VendorAddress = entity.VendorAddress 
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

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[GeneralAffair].[USP_DeleteVendor]";
                var param = new { VendorID = id };
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

        public IEnumerable<Vendor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAllVendor]";

                var results = conn.Query<Vendor>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Vendor GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[Vendors] Where [VendorID] = @VendorID ";
                var param = new { VendorID = id };
                var result = conn.QuerySingleOrDefault<Vendor>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Vendor> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[Vendors] Where [VendorName] like @VendorName ";
                var param = new { VendorName = $"%{name}%" };
                var result = conn.Query<Vendor>(strSql, param);
                return result;
            }
        }

        public void Update(Vendor entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_UpdateVendor]";
                    var param = new { VendorID = entity.VendorID, VendorName = entity.VendorName, VendorAddress = entity.VendorAddress };
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

        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public int GetCountVendors(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[Vendors] Where [VendorName] like @VendorName ";
                var param = new { VendorName = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<Vendor> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[Vendors] 
                              Where [VendorName] like @VendorName 
                              order by VendorName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { VendorName = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<Vendor>(strSql, param);
                return results;
            }
        }
    }
}
