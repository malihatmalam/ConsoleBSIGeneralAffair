using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Asset
    {
        public int? AssetID { get; set; }
        public short? BrandID { get; set; }
        public short? AssetCategoryID { get; set; }
        public string AssetFactoryNumber { get; set; }
        public string AssetNumber { get; set; }
        public string AssetName { get; set; }
        public decimal? AssetCost { get; set; }
        public string AssetProcurementDate { get; set; }
        public bool? AssetFlagActive { get; set; }
        public string AssetCondition { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public AssetCategory Category { get; set; }
        public List<AssetUser> UserAsset { get; set; }
        public Brand Brand { get; set; }
    }
}
