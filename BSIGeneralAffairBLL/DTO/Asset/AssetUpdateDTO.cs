using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Asset
{
    public class AssetUpdateDTO
    {
        public string AssetNumber { get; set; }
        public int? Brand { get; set; }
        public int? AssetCategoryID { get; set; }
        public string AssetFactoryNumber { get; set; }
        public string AsssetName { get; set; }
        public decimal? AssetCost { get; set; }
        public string AssetProcurementDate { get; set; }
        public bool? AssetFlagActive { get; set; }
        public string AssetCondition { get; set; }
    }
}
