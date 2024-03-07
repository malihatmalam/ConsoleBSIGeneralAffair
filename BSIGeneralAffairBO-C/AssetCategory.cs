using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class AssetCategory
    {
        public AssetCategory() {
            this.Assets = new List<Asset>();    
        }
        public short? AssetCategoryID { get; set; }
        public string AssetCategoryName { get; set; }
        public List<Asset> Assets { get; set; }
        public string UpdatedAt { get; set; }
    }
}
