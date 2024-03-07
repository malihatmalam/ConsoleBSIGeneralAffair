using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Office
{
    public class OfficeCreateDTO
    {
        public string OfficeName { get; set;}
        public string OfficeAddress { get; set;}
        public bool? OfficeFlagActive { get; set; }
    }
}
