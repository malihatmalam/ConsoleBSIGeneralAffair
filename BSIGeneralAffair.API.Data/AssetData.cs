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
    public class AssetData : IAssetData
    {
        private readonly AppDbContext _context;

        public AssetData(AppDbContext context)
        {
            _context = context;
        }

        private string GetConnectionString()
        {
            return DatabaseConnection.GetConnectionString();
        }

        public async Task<Asset> GetByNumber(string numberAsset)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    List<Asset> assets = new List<Asset>();
                    //var strSql = @"select * from Categories order by CategoryName";
                    var strSql = @"[GeneralAffair].[USP_GetDetailAssetInfo]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AssetNumber", $"{numberAsset}");

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Asset asset = new Asset();
                            asset.AssetId = Convert.ToInt32(dr["ID"]);
                            asset.Brand = new Brand();
                            asset.Brand.BrandName = dr["Brand"].ToString();
                            asset.Brand.BrandId = (byte)Convert.ToInt32(dr["BrandID"]);
                            asset.AssetCategory = new AssetCategory();
                            asset.AssetCategory.AssetCategoryName = dr["Category"].ToString();
                            asset.AssetCategory.AssetCategoryId = (byte)Convert.ToInt32(dr["CategoryID"]);
                            asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                            asset.AsssetName = dr["Name"].ToString();
                            asset.AssetCost = Convert.ToDecimal(dr["Cost"]);
                            asset.AssetNumber = dr["AssetNumber"].ToString();
                            asset.AssetProcurementDate = (DateTime)dr["ProcurementDate"];
                            asset.AssetCondition = dr["Condition"].ToString();

                            assets.Add(asset);
                        }
                    }
                    Asset assetData = new Asset();
                    assetData = assets[0];
                    return assetData;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Asset>> GetByUser(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    List<Asset> assets = new List<Asset>();
                    //var strSql = @"select * from Categories order by CategoryName";
                    var strSql = @"[GeneralAffair].[USP_Mobile_SelectMyAsset]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Asset asset = new Asset();
                            asset.AssetId = Convert.ToInt32(dr["AssetID"]);
                            asset.Brand = new Brand();
                            asset.Brand.BrandName = dr["Brand"].ToString();
                            asset.AssetCategory = new AssetCategory();
                            asset.AssetCategory.AssetCategoryName = dr["CategoryName"].ToString();
                            asset.AssetFactoryNumber = dr["FactoryNumber"].ToString();
                            asset.AssetNumber = dr["AssetNumber"].ToString();
                            asset.AsssetName = dr["AsssetName"].ToString();
                            asset.AssetCost = Convert.ToDecimal(dr["AssetCost"]);
                            asset.AssetCondition = dr["AssetCondition"].ToString();

                            assets.Add(asset);
                        }
                    }
                    return assets;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<IEnumerable<AssetUser>> GetHandsoverHistory(int assetID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    List<AssetUser> assetUsers = new List<AssetUser>();
                    //var strSql = @"select * from Categories order by CategoryName";
                    var strSql = @"[GeneralAffair].[USP_GetHandsoverAssetHistory]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetID", assetID);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AssetUser assetUser = new AssetUser();
                            assetUser.AssetUserId = Convert.ToInt32(dr["ID"]);
                            assetUser.UserId = Convert.ToInt32(dr["UserID"]);
                            assetUser.AssetId = assetID;
                            assetUser.HandoverDateTime = DateTime.Parse(dr["HandoverDateTime"].ToString());
                            User user = new User();
                            assetUser.User = user;
                            assetUser.User.UserFirstName = dr["UserFullname"].ToString();

                            assetUsers.Add(assetUser);
                        }
                    }
                    return assetUsers;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }
    }
}
