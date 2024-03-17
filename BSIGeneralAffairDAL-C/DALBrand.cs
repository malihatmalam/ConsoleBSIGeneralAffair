using BSIGeneralAffairBO;
using BSIGeneralAffairDAL_C.Interfaces;
using GeneralAffairInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using static Dapper.SqlMapper;

namespace BSIGeneralAffairDAL_C
{
    public class DALBrand : IBrandDAL
    {
        public void Insert(Brand entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[GeneralAffair].[USP_StoreBrand]";
                var param = new { BrandName = entity.BrandName };
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
                var strSql = @"[GeneralAffair].[USP_DeleteBrand]";
                var param = new { BrandID = id };
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

        public IEnumerable<Brand> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAllBrand]";

                var results = conn.Query<Brand>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Brand GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[Brands] Where [BrandID] = @BrandID ";
                var param = new { BrandID = id };
                var result = conn.QuerySingleOrDefault<Brand>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Brand> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[Brands] Where [BrandName] = @BrandName ";
                var param = new { BrandName = name };
                var result = conn.Query<Brand>(strSql, param);
                return result;
            }
        }

        public void Update(Brand entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_UpdateBrand]";
                    var param = new { BrandID = entity.BrandID , BrandName = entity.BrandName };
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

        public int GetCountBrands(string name) 
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) 
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[Brands] Where [BrandName] like @BrandName ";
                var param = new { BrandName = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<Brand> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) 
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[Brands] 
                              Where [BrandName] like @BrandName 
                              order by BrandName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { BrandName = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<Brand>(strSql, param);
                return results;
            }
        }
    }
}
