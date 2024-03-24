using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IAssetBLL
    {
        Task<IEnumerable<AssetDTO>> GetByUser(int userId);
        Task<AssetDTO> GetByNumber(string numberAsset);
        Task<IEnumerable<AssetUserDTO>> GetHandsoverHistory(int assetID);
    }
}
