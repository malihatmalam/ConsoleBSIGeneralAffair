using BSIGeneralAffairBLL.DTO.Asset;
using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Category;
using BSIGeneralAffairBLL.DTO.Office;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace BSIGeneralAffairBLL
{
    public class AssetBLL : IAssetBLL
    {
        private readonly IAssetDAL _assetDAL;

        public AssetBLL()
        {
            _assetDAL = new DALAsset();
        }

        public void Delete(string assetNumber)
        {
            if (assetNumber == null)
            {
                throw new ArgumentException("Asset number is required");
            }

            try
            {
                _assetDAL.Delete(assetNumber);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<AssetDTO> GetAll()
        {
            List<AssetDTO> listAssetsDTO = new List<AssetDTO>();
            var assets = _assetDAL.GetAll();
            foreach (var asset in assets)
            {
                listAssetsDTO.Add(new AssetDTO
                {
                    AssetID = asset.AssetID,
                    AssetBrand = asset.Brand.BrandName,
                    AssetCategory = asset.Category.AssetCategoryName,
                    FactoryNumber = asset.AssetFactoryNumber,
                    AssetNumber = asset.AssetNumber,
                    Name = asset.AssetName,
                    Cost = asset.AssetCost,
                    ProcurementDate = asset.AssetProcurementDate.ToString(),
                    Condition = asset.AssetCondition,
                    AssetFlagActive = asset.AssetFlagActive,
                    CreatedAt = asset.CreatedAt.ToString(),
                    UpdatedAt = asset.UpdatedAt.ToString(),
                });
            }
            return listAssetsDTO;
        }

        public AssetDTO GetByAssetID(int assetID)
        {
            AssetDTO assetDTO = new AssetDTO();
            var asset = _assetDAL.GetById(assetID);
            if (asset != null)
            {
                assetDTO.AssetID = asset.AssetID;
                assetDTO.AssetBrand = asset.Brand.BrandName;
                assetDTO.AssetCategory = asset.Category.AssetCategoryName;
                assetDTO.FactoryNumber = asset.AssetFactoryNumber;
                assetDTO.AssetNumber = asset.AssetNumber;
                assetDTO.Name = asset.AssetName;
                assetDTO.Cost = asset.AssetCost;
                assetDTO.ProcurementDate = asset.AssetProcurementDate.ToString();
                assetDTO.Condition = asset.AssetCondition;
                assetDTO.AssetFlagActive = asset.AssetFlagActive;
                assetDTO.CreatedAt = asset.CreatedAt.ToString();
                assetDTO.UpdatedAt = asset.UpdatedAt.ToString();
            }
            else
            {
                throw new ArgumentException($"Asset {assetID} not found");
            }
            return assetDTO;
        }

        public IEnumerable<AssetDTO> GetByName(string name)
        {
            List<AssetDTO> listAssetsDTO = new List<AssetDTO>();
            var assets = _assetDAL.GetByName(name);
            foreach (var asset in assets)
            {
                listAssetsDTO.Add(new AssetDTO
                {
                    AssetID = asset.AssetID,
                    AssetBrand = asset.Brand.BrandName,
                    AssetCategory = asset.Category.AssetCategoryName,
                    FactoryNumber = asset.AssetFactoryNumber,
                    AssetNumber = asset.AssetNumber,
                    Name = asset.AssetName,
                    Cost = asset.AssetCost,
                    ProcurementDate = asset.AssetProcurementDate.ToString(),
                    Condition = asset.AssetCondition,
                    AssetFlagActive = asset.AssetFlagActive,
                    CreatedAt = asset.CreatedAt.ToString(),
                    UpdatedAt = asset.UpdatedAt.ToString(),
                });
            }
            return listAssetsDTO;
        }

        public IEnumerable<AssetDTO> GetByNumberAsset(string numberAsset)
        {
            List<AssetDTO> listAssetsDTO = new List<AssetDTO>();
            var assets = _assetDAL.GetByNumberAsset(numberAsset);
            foreach (var asset in assets)
            {
                listAssetsDTO.Add(new AssetDTO
                {
                    AssetID = asset.AssetID,
                    AssetBrand = asset.Brand.BrandName,
                    AssetCategory = asset.Category.AssetCategoryName,
                    FactoryNumber = asset.AssetFactoryNumber,
                    AssetNumber = asset.AssetNumber,
                    Name = asset.AssetName,
                    Cost = asset.AssetCost,
                    ProcurementDate = asset.AssetProcurementDate.ToString(),
                    Condition = asset.AssetCondition,
                    AssetFlagActive = asset.AssetFlagActive,
                    CreatedAt = asset.CreatedAt.ToString(),
                    UpdatedAt = asset.UpdatedAt.ToString(),
                });
            }
            return listAssetsDTO;
        }

        public int GetCountAssets(string name)
        {
            return _assetDAL.GetCountAssets(name);
        }

        public IEnumerable<AssetUserDTO> GetHandsoverHistoryAsset(int assetID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<AssetDTO> listAssetsDTO = new List<AssetDTO>();
            var assets = _assetDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var asset in assets)
            {
                listAssetsDTO.Add(new AssetDTO
                {
                    AssetID = asset.AssetID,
                    AssetBrand = asset.Brand.BrandName,
                    AssetCategory = asset.Category.AssetCategoryName,
                    FactoryNumber = asset.AssetFactoryNumber,
                    AssetNumber = asset.AssetNumber,
                    Name = asset.AssetName,
                    Cost = asset.AssetCost,
                    ProcurementDate = asset.AssetProcurementDate.ToString(),
                    Condition = asset.AssetCondition,
                    AssetFlagActive = asset.AssetFlagActive,
                    CreatedAt = asset.CreatedAt.ToString(),
                    UpdatedAt = asset.UpdatedAt.ToString(),
                });
            }
            return listAssetsDTO;
        }

        public void HandsoverAsset(UserDTO userHandsover, AssetDTO assetHandsover)
        {
            throw new NotImplementedException();
        }

        public void Insert(AssetCreateDTO newAsset)
        {
            if (string.IsNullOrEmpty(newAsset.Brand.ToString()))
            {
                throw new ArgumentException("Brand is required");
            }
            if (string.IsNullOrEmpty(newAsset.AssetCategoryID.ToString()))
            {
                throw new ArgumentException("Category name is required");
            }
            if (string.IsNullOrEmpty(newAsset.AssetFactoryNumber))
            {
                throw new ArgumentException("Factory number is required");
            }
            if (string.IsNullOrEmpty(newAsset.AssetNumber))
            {
                throw new ArgumentException("Asset number is required");
            }
            if (string.IsNullOrEmpty(newAsset.AsssetName))
            {
                throw new ArgumentException("Asset name is required");
            }
            if (string.IsNullOrEmpty(newAsset.AssetCost.ToString()))
            {
                throw new ArgumentException("Asset cost is required");
            }
            if (string.IsNullOrEmpty(newAsset.AssetProcurementDate))
            {
                throw new ArgumentException("Procurement date is required");
            }
            //else if (newCategory.AssetCategoryName.Length > 50)
            //{
            //    throw new ArgumentException("Category name max length is 50");
            //}

            try
            {
                var assetDTO = new Asset
                {

                    BrandID = (short?)newAsset.Brand,
                    AssetCategoryID = (short?)newAsset.AssetCategoryID,
                    AssetFactoryNumber = newAsset.AssetFactoryNumber,
                    AssetNumber = newAsset.AssetNumber,
                    AssetName = newAsset.AsssetName,
                    AssetCost = newAsset.AssetCost,
                    AssetProcurementDate = newAsset.AssetProcurementDate,
                    AssetFlagActive = true,
                    AssetCondition = "New"
                };
                _assetDAL.Insert(assetDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(AssetUpdateDTO updateAsset)
        {
            if (string.IsNullOrEmpty(updateAsset.Brand.ToString()))
            {
                throw new ArgumentException("Brand is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetCategoryID.ToString()))
            {
                throw new ArgumentException("Category name is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetFactoryNumber))
            {
                throw new ArgumentException("Factory number is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetNumber))
            {
                throw new ArgumentException("Asset number is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AsssetName))
            {
                throw new ArgumentException("Asset name is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetCost.ToString()))
            {
                throw new ArgumentException("Asset cost is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetProcurementDate))
            {
                throw new ArgumentException("Procurement date is required");
            }
            if (string.IsNullOrEmpty(updateAsset.AssetCondition))
            {
                throw new ArgumentException("Asset condition  is required");
            }
            //else if (newCategory.AssetCategoryName.Length > 50)
            //{
            //    throw new ArgumentException("Category name max length is 50");
            //}

            try
            {
                var assetDTO = new Asset
                {

                    BrandID = (short?)updateAsset.Brand,
                    AssetCategoryID = (short?)updateAsset.AssetCategoryID,
                    AssetFactoryNumber = updateAsset.AssetFactoryNumber,
                    AssetNumber = updateAsset.AssetNumber,
                    AssetName = updateAsset.AsssetName,
                    AssetCost = updateAsset.AssetCost,
                    AssetProcurementDate = updateAsset.AssetProcurementDate,
                    AssetFlagActive = true,
                    AssetCondition = updateAsset.AssetCondition,
                };
                _assetDAL.Update(assetDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
