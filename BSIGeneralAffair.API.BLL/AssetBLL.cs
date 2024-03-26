using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL
{
    public class AssetBLL : IAssetBLL
    {
        private readonly IAssetData _assetData;
        private readonly IMapper _mapper;

        public AssetBLL(IAssetData assetData, IMapper mapper)
        {
            _assetData = assetData;
            _mapper = mapper;
        }   

        public async Task<AssetDTO> GetByNumber(string numberAsset)
        {
            try
            {
                var asset = _mapper.Map<AssetDTO>(await _assetData.GetByNumber(numberAsset));
                return asset;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<IEnumerable<AssetDTO>> GetByUser(string employeeNumber)
        {
            try
            {
                var assets = _mapper.Map<IEnumerable<AssetDTO>>(await _assetData.GetByUser(employeeNumber));
                return assets;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<IEnumerable<AssetUserDTO>> GetHandsoverHistory(int assetID)
        {
            try
            {
                var assetUsers = _mapper.Map<IEnumerable<AssetUserDTO>>(await _assetData.GetHandsoverHistory(assetID));
                return assetUsers;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }
    }
}
