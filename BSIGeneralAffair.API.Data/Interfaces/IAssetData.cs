using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IAssetData
    {
        Task<IEnumerable<Asset>> GetByUser(int userId);
        Task<Asset> GetByNumber(string numberAsset);
        Task<IEnumerable<AssetUser>> GetHandsoverHistory(int assetID);
    }
}
