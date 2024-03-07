﻿using BSIGeneralAffairBLL.DTO.Asset;
using BSIGeneralAffairBLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IAssetBLL
    {
        IEnumerable<AssetDTO> GetAll();
        void Insert(AssetCreateDTO newAsset);
        void Update(AssetUpdateDTO updateAsset);
        void Delete(string assetNumber);
        AssetDTO GetByAssetID(int assetID);
        IEnumerable<AssetDTO> GetByName(string name);
        IEnumerable<AssetDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountAssets(string name);
        IEnumerable<AssetDTO> GetByNumberAsset(string numberAsset);
        void HandsoverAsset(UserDTO userHandsover, AssetDTO assetHandsover);
        IEnumerable<AssetUserDTO> GetHandsoverHistoryAsset(int assetID);
    }
}