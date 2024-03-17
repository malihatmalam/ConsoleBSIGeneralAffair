using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Office
{
    public class OfficeUpdateDTO
    {
        [Required(ErrorMessage = "kantor id harus diisi")]
        public int OfficeID { get; set; }
        [Required(ErrorMessage = "Nama kantor harus diisi")]
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public bool? OfficeFlagActive { get; set; }
    }
}
