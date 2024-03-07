using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace BSIGeneralAffairDAL_C
{
    public class DALAsset : IAssetDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Delete(string assetNumber)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"[GeneralAffair].[USP_DeleteAsset]";
                var param = new { AssetNumber = assetNumber };
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

        public IEnumerable<Asset> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Asset> assets = new List<Asset>();
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAllAsset]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows) {
                    while (dr.Read()) {
                        Asset asset = new Asset();
                        asset.AssetID = Convert.ToInt32(dr["ID"]);
                        asset.Brand = new Brand();
                        asset.Brand.BrandName = dr["Brand"].ToString();
                        asset.Category = new AssetCategory();
                        asset.Category.AssetCategoryName = dr["Category"].ToString();
                        asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                        asset.AssetName = dr["Name"].ToString();
                        asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                        asset.AssetProcurementDate = dr["ProcurementDate"].ToString();
                        asset.AssetCondition = dr["Condition"].ToString();

                        assets.Add(asset);
                    }
                }
                return assets;
            }
        }

        public Asset GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Asset> assets = new List<Asset>();
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_GetAssetById]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AssetID", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Asset asset = new Asset();
                        asset.AssetID = Convert.ToInt32(dr["ID"]);
                        asset.Brand = new Brand();
                        asset.Brand.BrandName = dr["Brand"].ToString();
                        asset.Category = new AssetCategory();
                        asset.Category.AssetCategoryName = dr["Category"].ToString();
                        asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                        asset.AssetName = dr["Name"].ToString();
                        asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                        asset.AssetProcurementDate = dr["ProcurementDate"].ToString();
                        asset.AssetCondition = dr["Condition"].ToString();

                        assets.Add(asset);
                    }
                }
                Asset assetFirst = new Asset();

                if (assets.Count != 0)
                {
                    assetFirst = assets[0];
                }

                return assetFirst;          
            }
        }

        public IEnumerable<Asset> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Asset> assets = new List<Asset>();
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAssetByName]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AsssetName", $"%{name}%");

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Asset asset = new Asset();
                        asset.AssetID = Convert.ToInt32(dr["ID"]);
                        asset.Brand = new Brand();
                        asset.Brand.BrandName = dr["Brand"].ToString();
                        asset.Category = new AssetCategory();
                        asset.Category.AssetCategoryName = dr["Category"].ToString();
                        asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                        asset.AssetName = dr["Name"].ToString();
                        asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                        asset.AssetProcurementDate = dr["ProcurementDate"].ToString();
                        asset.AssetCondition = dr["Condition"].ToString();

                        assets.Add(asset);
                    }
                }
                return assets;
            }
        }

        public IEnumerable<Asset> GetByNumberAsset(string numberAsset)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Asset> assets = new List<Asset>();
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_GetDetailAssetInfo]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AssetNumber", $"%{numberAsset}%");

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Asset asset = new Asset();
                        asset.AssetID = Convert.ToInt32(dr["ID"]);
                        asset.Brand = new Brand();
                        asset.Brand.BrandName = dr["Brand"].ToString();
                        asset.Category = new AssetCategory();
                        asset.Category.AssetCategoryName = dr["Category"].ToString();
                        asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                        asset.AssetName = dr["Name"].ToString();
                        asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                        asset.AssetProcurementDate = dr["ProcurementDate"].ToString();
                        asset.AssetCondition = dr["Condition"].ToString();

                        assets.Add(asset);
                    }
                }
                return assets;
            }
        }

        public int GetCountAssets(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[Assets] Where [AssetID] like @AssetID";
                var param = new { AssetID = $"%{name}%" };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }
        }

        public IEnumerable<AssetUser> GetHandsoverHistoryAsset(int assetID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Asset> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Asset> assets = new List<Asset>();
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"[GeneralAffair].[USP_SelectAssetWithPagging]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsssetName", $"%{name}%");
                cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Asset asset = new Asset();
                        asset.AssetID = Convert.ToInt32(dr["ID"]);
                        asset.Brand = new Brand();
                        asset.Brand.BrandName = dr["Brand"].ToString();
                        asset.Category = new AssetCategory();
                        asset.Category.AssetCategoryName = dr["Category"].ToString();
                        asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                        asset.AssetName = dr["Name"].ToString();
                        asset.AssetNumber = dr["AssetNumber"].ToString();
                        asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                        asset.AssetProcurementDate = dr["ProcurementDate"].ToString();
                        asset.AssetCondition = dr["Condition"].ToString();

                        assets.Add(asset);
                    }
                }
                return assets;
            }
        }

        public void HandsoverAsset(User userHandsover, Asset assetHandsover)
        {
            throw new NotImplementedException();
        }

        public void Insert(Asset entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "[GeneralAffair].[USP_StoreAsset]";
                var param = new 
                {
                    BrandID = entity.BrandID,
                    AssetCategoryID = entity.AssetCategoryID,
                    AssetFactoryNumber = entity.AssetFactoryNumber,
                    AssetNumber = entity.AssetNumber,
                    AsssetName = entity.AssetName,
                    AssetCost = entity.AssetCost,
                    AssetProcurementDate = entity.AssetProcurementDate,
                    AssetFlagActive = entity.AssetFlagActive,
                    AssetCondition = entity.AssetCondition
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

        public void Update(Asset entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_UpdateAsset]";
                    var param = new {
                        AssetNumber = entity.AssetNumber,
                        BrandID = entity.BrandID,
                        AssetCategoryID = entity.AssetCategoryID,
                        AssetFactoryNumber = entity.AssetFactoryNumber,
                        AsssetName = entity.AssetName,
                        AssetCost = entity.AssetCost,
                        AssetProcurementDate = entity.AssetProcurementDate,
                        AssetFlagActive = entity.AssetFlagActive,
                        AssetCondition = entity.AssetCondition,
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
