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
    public class DALCategory : ICategoryDAL
    {
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[GeneralAffair].[USP_DeleteCategoryAsset]";
                var param = new { AssetCategoryID = id };
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

        public IEnumerable<AssetCategory> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAllCategoryAsset]";

                var results = conn.Query<AssetCategory>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public AssetCategory GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[AssetCategories] Where [AssetCategoryID] = @AssetCategoryID ";
                var param = new { AssetCategoryID = id };
                var result = conn.QuerySingleOrDefault<AssetCategory>(strSql, param);
                return result;
            }
        }

        public IEnumerable<AssetCategory> GetByNamesCategory(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[AssetCategories] Where [AssetCategoryName] = @AssetCategoryName ";
                var param = new { AssetCategoryName = name };
                var result = conn.Query<AssetCategory>(strSql, param);
                return result;
            }
        }

        public int GetCountCategory(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[AssetCategories] Where [AssetCategoryName] = @AssetCategoryName ";
                var param = new { AssetCategoryName = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<AssetCategory> GetWithPagingCategory(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM [GeneralAffair].[AssetCategories]
                              Where [AssetCategoryName] like @AssetCategoryName 
                              order by AssetCategoryName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { AssetCategoryName = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<AssetCategory>(strSql, param);
                return results;
            }
        }

        public void Insert(AssetCategory entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[GeneralAffair].[USP_StoreCategoryAsset]";
                var param = new
                {
                    AssetCategoryName = entity.AssetCategoryName
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

        public void Update(AssetCategory entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_UpdateCategoryAsset]";
                    var param = new
                    {
                        AssetCategoryID = entity.AssetCategoryID,
                        AssetCategoryName = entity.AssetCategoryName
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
