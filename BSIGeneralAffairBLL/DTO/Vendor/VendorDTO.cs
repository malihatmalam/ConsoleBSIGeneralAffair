using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Vendor
{
    public class VendorDTO
    {
        public int VendorID { get; set; }
        public string VendorName { get; set;}
        public string VendorAddress { get; set;}
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set;}
    }
}
