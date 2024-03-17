using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Vendor
{
    public class VendorUpdateDTO
    {
        [Required(ErrorMessage = "ID vendor harus diisi")]
        public int VendorID { get; set; }
        [Required(ErrorMessage = "Nama vendor harus diisi")]
        public String VendorName { get; set;}
        public String VendorAddress { get; set; }
    }
}
