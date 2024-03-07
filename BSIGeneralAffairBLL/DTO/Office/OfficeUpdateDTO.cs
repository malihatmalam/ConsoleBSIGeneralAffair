using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Office
{
    public class OfficeUpdateDTO
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public bool? OfficeFlagActive { get; set; }
    }
}
