using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Asset
{
    public class AssetDTO
    {
        public int? AssetID { get; set; }
        public int? BrandID { get; set; }
        public short? CategoryID { get; set; }
        public string AssetBrand { get; set; }
        public string AssetCategory { get; set; }
        public string FactoryNumber { get; set; }
        public string AssetNumber { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public DateTime ProcurementDate { get; set; }
        public string Condition { get; set; }
        public bool? AssetFlagActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public CategoryDTO Category { get; set; }
        public List<AssetUserDTO> UserAsset { get; set; }
        public BrandDTO Brand { get; set; }
    }
}
