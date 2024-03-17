using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Vendor
{
    public class VendorCreateDTO
    {
        [Required(ErrorMessage = "Nama vendor harus diisi")]
        public String VendorName { get; set; }
        public string VendorAddress { get; set; }
    }
}
