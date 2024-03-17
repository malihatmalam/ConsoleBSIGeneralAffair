using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Office
{
    public class OfficeCreateDTO
    {
        [Required(ErrorMessage = "Nama kantor harus diisi")]
        public string OfficeName { get; set;}
        [Required(ErrorMessage = "alamat kantor harus diisi")]
        public string OfficeAddress { get; set;}
        public bool? OfficeFlagActive { get; set; }
    }
}
