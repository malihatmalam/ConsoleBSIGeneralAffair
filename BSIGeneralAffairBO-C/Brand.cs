using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Brand
    {
        public Brand() { 
            this.Assets = new List<Asset>();
        }
        public short? BrandID { get; set; }
        public string BrandName { get; set; }
        public string UpdatedAt { get; set; }
        public List<Asset> Assets { get; set; }
    }

}
