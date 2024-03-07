﻿using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IAssetDAL 
    {
        IEnumerable<Asset> GetAll();
        Asset GetById(int id);
        void Insert(Asset entity);
        void Update(Asset entity);
        void Delete(string assetNumber);
        IEnumerable<Asset> GetByName(string name);
        int GetCountAssets(string name);
        IEnumerable<Asset> GetWithPaging(int pageNumber, int pageSize, string name);
        IEnumerable<Asset> GetByNumberAsset(string numberAsset);
        void HandsoverAsset(User userHandsover, Asset assetHandsover);
        IEnumerable<AssetUser> GetHandsoverHistoryAsset(int assetID);
    }
}
